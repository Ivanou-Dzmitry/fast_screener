
using fast_screener;
using fast_screener.Properties;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;


namespace screener3
{

    public partial class FormSet : Form
    {

        private string limitsText = "Limits (WxH): max " + FormMain.VirtScreenWidth.ToString() + "x" + FormMain.VirtScreenHeight.ToString() + ", min " + FormMain.MIN_WIDTH.ToString() + "x" + FormMain.MIN_HEIGHT.ToString();
        private bool lockPadding;
        private int lockedPadding;
        int defaultPadding = 10;

        public FormSet()
        {
            InitializeComponent();

            //select grid in list
            lboxSetCat.SetSelected(0, true);
            ArrowSettings();

            //hypotinusa
            int arrowLenght = Convert.ToInt32(CalcHypo(FormMain.clientWidth, FormMain.pnlToolBarH));

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

        }


        //PARSE GRID
        private void ParseGridItems(GridItem gi)
        {
            if (gi.GridItemType == GridItemType.Category)
            {
                foreach (GridItem item in gi.GridItems)
                {
                    ParseGridItems(item);
                }
            }

            if (gi.Value != null)
                SavePropGrid(gi.Label, gi.Value.ToString());

        }

        //SAVE GRID
        private void SavePropGrid(string label, string value)
        {
            switch (label)
            {
                case "Lock Padding":
                    FormMain.indentValueLock = Convert.ToBoolean(value.ToLower());
                    break;
                case "Bottom Padding":
                    FormMain.CUSTOM_GRID[1] = int.Parse(value);

                    lockedPadding = int.Parse(value);

                    if (lockedPadding <= 0)
                    {
                        lockedPadding = defaultPadding;
                        FormMain.CUSTOM_GRID[1] = lockedPadding;
                    }

                    break;
                case "Top Padding":

                    int CurrentValueT = int.Parse(value);

                    if (lockPadding == true)
                    {
                        FormMain.CUSTOM_GRID[0] = lockedPadding;
                    }
                    else
                    {
                        FormMain.CUSTOM_GRID[0] = CurrentValueT;
                    }

                    if (CurrentValueT <= 0)
                    {
                        FormMain.CUSTOM_GRID[0] = defaultPadding;
                    }

                    break;
                case "Left Padding":

                    int CurrentValueL = int.Parse(value);

                    if (lockPadding == true)
                    {
                        FormMain.CUSTOM_GRID[2] = lockedPadding;
                    }
                    else
                    {
                        FormMain.CUSTOM_GRID[2] = CurrentValueL;
                    }

                    if (CurrentValueL <= 0)
                    {
                        FormMain.CUSTOM_GRID[2] = defaultPadding;
                    }
                    break;
                case "Right Padding":

                    int CurrentValueR = int.Parse(value);

                    if (lockPadding == true)
                    {
                        FormMain.CUSTOM_GRID[3] = lockedPadding;
                    }
                    else
                    {
                        FormMain.CUSTOM_GRID[3] = CurrentValueR;
                    }

                    if (CurrentValueR <= 0)
                    {
                        FormMain.CUSTOM_GRID[3] = defaultPadding;
                    }
                    break;
                case "Grid Color":
                    FormMain.gridColor = stringToColor(value);
                    break;
                case "Grid Type":

                    string tempType = value;

                    switch (tempType)
                    {
                        case "3x3":
                            FormMain.GridType = 1;
                            break;
                        case "4x4":
                            FormMain.GridType = 2;
                            break;
                        case "Custom":
                            FormMain.GridType = 3;
                            break;
                        default:
                            break;
                    }

                    break;

                case "Arrow Lenght":

                    int CurrentArrowValue = int.Parse(value);
                    double MaxArrowValue = CalcHypo(FormMain.clientWidth, FormMain.clientHeight);


                    if (CurrentArrowValue > Convert.ToInt32(MaxArrowValue))
                    {
                        FormMain.arrowLenght = Convert.ToInt32(MaxArrowValue);
                    }
                    else
                    {
                        FormMain.arrowLenght = (int)(CurrentArrowValue);
                    }

                    if (CurrentArrowValue < 8)
                    {
                        FormMain.arrowLenght = (int)(50); //default value
                    }


                    break;
                case "Arrow Color":
                    FormMain.arrowColor = stringToColor(value);
                    break;

                case "Number Font Size":

                    int currentFontSize = int.Parse(value);

                    double MaxFontSizeValue = CalcHypo(FormMain.clientWidth, FormMain.clientHeight) / 2.5; //to fit into the screen at the current resolution

                    if (currentFontSize > Convert.ToInt32(MaxFontSizeValue))
                    {
                        currentFontSize = Convert.ToInt32(MaxFontSizeValue);
                    }

                    if (currentFontSize < 8)
                    {
                        FormMain.numberFontSize = 26; //default size
                    }
                    else
                    {
                        FormMain.numberFontSize = currentFontSize;
                    }

                    break;
                case "Number Color":
                    FormMain.numberColor = stringToColor(value);
                    break;
                case "1.1 Width":
                    FormMain.RES_WORKED[0, 0] = sizeChecker(Convert.ToInt32(value), "width");
                    break;
                case "1.2 Height":
                    FormMain.RES_WORKED[1, 0] = sizeChecker(Convert.ToInt32(value), "height");
                    break;
                case "2.1 Width":
                    FormMain.RES_WORKED[0, 1] = sizeChecker(Convert.ToInt32(value), "width");
                    break;
                case "2.2 Height":
                    FormMain.RES_WORKED[1, 1] = sizeChecker(Convert.ToInt32(value), "height");
                    break;
                case "3.1 Width":
                    FormMain.RES_WORKED[0, 2] = sizeChecker(Convert.ToInt32(value), "width");
                    break;
                case "3.2 Height":
                    FormMain.RES_WORKED[1, 2] = sizeChecker(Convert.ToInt32(value), "height");
                    break;
                case "4.1 Width":
                    FormMain.RES_WORKED[0, 3] = sizeChecker(Convert.ToInt32(value), "width");
                    break;
                case "4.2 Height":
                    FormMain.RES_WORKED[1, 3] = sizeChecker(Convert.ToInt32(value), "height");
                    break;
                case "Frame Color":
                    FormMain.frameColor = stringToColor(value);
                    break;
                case "Frame Width":
                    int currentW = int.Parse(value);
                    if (currentW > FormMain.clientWidth | currentW < FormMain.FrameMinSize)
                    {
                        FormMain.FrameWidth = FormMain.FrameInitialSize;
                    }
                    else
                    {
                        FormMain.FrameWidth = currentW;
                    }
                    break;
                case "Frame Height":
                    int currentH = int.Parse(value);
                    if (currentH > FormMain.clientHeight | currentH < FormMain.FrameMinSize)
                    {
                        FormMain.FrameWidth = FormMain.FrameInitialSize;
                    }
                    else
                    {
                        FormMain.FrameHeight = currentH;
                    }
                    break;

                default:
                    break;
            }
        }

        private void SettingCloseActions()
        {

            GridItem gi = pgSettings.SelectedGridItem;

            while (gi.Parent != null)
            {
                gi = gi.Parent;
            }
            foreach (GridItem item in gi.GridItems)
            {
                ParseGridItems(item); //recursive
            }

        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            //set data update
            SettingCloseActions();

            pgSettings.Refresh();

            Close();
        }


        private double CalcHypo(int width, int height)
        {
            double side1, side2, hypo;
            side1 = Convert.ToDouble(width);
            side2 = Convert.ToDouble(height);
            hypo = Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2));

            return hypo;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //set data update
            SettingCloseActions();
        }

        public class PaddingHorConverter : Int16Converter
        {
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) && value is int && Convert.ToInt32(value) < FormMain.clientHeight / 2)
                {
                    return ((int)value).ToString();
                }
                else
                {
                    value = "Value too large!";
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

        }

        public class PaddingVertConverter : Int16Converter
        {
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) && value is int && Convert.ToInt32(value) < FormMain.clientWidth / 2)
                {
                    return ((int)value).ToString();
                }
                else
                {
                    value = "Value too large!";
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

        }
        public class FormatStringConverter : StringConverter
        {
            public override Boolean GetStandardValuesSupported(ITypeDescriptorContext context) { return true; }
            public override Boolean GetStandardValuesExclusive(ITypeDescriptorContext context) { return true; }
            public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
            {
                List<String> list = new List<String>();
                list.Add("3x3");
                list.Add("4x4");
                list.Add("Custom");
                return new StandardValuesCollection(list);
            }
        }

        //GRID
        public class Grid
        {
            [Category("1. General Settings")]
            [DisplayName("Grid Type")]
            [Description("Choose grid type. 3x3 and 4x4 divides the area into equal parts, custom - set arbitrary padding.")]
            [TypeConverter(typeof(FormatStringConverter))]
            public string Type
            {
                get;
                set;
            }

            [TypeConverter(typeof(PaddingHorConverter))]
            [Category("2. Custom Type Settings")]
            [Description("Max size screenshot height/2. Minimum - 1. Default - 10.")]
            [DisplayName("Top Padding")]
            public int PaddingTop
            {
                get;
                set;
            }

            [TypeConverter(typeof(PaddingHorConverter))]
            [Category("2. Custom Type Settings")]
            [Description("Max size screenshot height/2. Lock Padding source.  Minimum - 1. Default - 10.")]
            [DisplayName("Bottom Padding")]
            public int PaddingBottom
            {
                get;
                set;
            }

            [TypeConverter(typeof(PaddingVertConverter))]
            [Category("2. Custom Type Settings")]
            [Description("Max size screenshot width/2. Minimum - 1. Default - 10.")]
            [DisplayName("Left Padding")]
            public int PaddingLeft
            {
                get;
                set;
            }

            [TypeConverter(typeof(PaddingVertConverter))]
            [Category("2. Custom Type Settings")]
            [Description("Max size screenshot width/2. Minimum - 1. Default - 10.")]
            [DisplayName("Right Padding")]
            public int PaddingRight
            {
                get;
                set;
            }


            [Category("1. General Settings")]
            [Description("Set grid color.")]
            [DisplayName("Grid Color")]
            public Color Color
            {
                get;
                set;
            }

            [Category("1. General Settings")]
            [Description("For Custom grid type. Set Bottom padding - other paddings change automatically.")]
            [DisplayName("Lock Padding")]
            public Boolean LockPadding
            {
                get;
                set;
            }

        }

        //LOAD GRID SETTINGS
        private void GridSettings()
        {
            Grid grid = new Grid();

            int tempType = FormMain.GridType;

            switch (tempType)
            {
                case 1:
                    grid.Type = "3x3";
                    break;
                case 2:
                    grid.Type = "4x4";
                    break;
                case 3:
                    grid.Type = "Custom";
                    break;
                default:
                    break;
            }



            grid.Color = FormMain.gridColor;

            grid.LockPadding = FormMain.indentValueLock;

            lockPadding = grid.LockPadding;

            grid.PaddingBottom = (int)FormMain.CUSTOM_GRID[1];

            if (grid.LockPadding == true)
            {
                grid.PaddingTop = (int)FormMain.CUSTOM_GRID[1];
                grid.PaddingLeft = (int)FormMain.CUSTOM_GRID[1];
                grid.PaddingRight = (int)FormMain.CUSTOM_GRID[1];
            }
            else
            {
                grid.PaddingTop = (int)FormMain.CUSTOM_GRID[0];
                grid.PaddingLeft = (int)FormMain.CUSTOM_GRID[2];
                grid.PaddingRight = (int)FormMain.CUSTOM_GRID[3];
            }

            pgSettings.SelectedObject = grid;
        }


        //ARROW
        class Arrow
        {
            [Category("Arrow Settings")]
            [Description("Set arrow lenght. The maximum length is equal to the hypotenuse. Minimum - 8. Default - 50.")]
            [DisplayName("Arrow Lenght")]
            public int Length
            {
                get;
                set;
            }

            [Category("Arrow Settings")]
            [Description("Set arrow color.")]
            [DisplayName("Arrow Color")]
            public Color Color
            {
                get;
                set;
            }
        }

        //Arrow set
        private void ArrowSettings()
        {
            Arrow arrow = new Arrow();

            arrow.Color = FormMain.arrowColor;
            arrow.Length = FormMain.arrowLenght;

            pgSettings.SelectedObject = arrow;
        }

        //NUMBER
        class Numbers
        {
            [Category("Numbers Settings")]
            [Description("Set number font size. Minimum - 8. Default - 26.")]
            [DisplayName("Number Font Size")]
            public int Size
            {
                get;
                set;
            }

            [Category("Numbers Settings")]
            [Description("Set numbers color.")]
            [DisplayName("Number Color")]
            public Color Color
            {
                get;
                set;
            }
        }

        //Numbers set
        private void NumbersSettings()
        {
            Numbers numbers = new Numbers();

            numbers.Color = FormMain.numberColor;
            numbers.Size = FormMain.numberFontSize;

            pgSettings.SelectedObject = numbers;

        }

        public class ResWidthConverter : Int16Converter
        {
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) && value is int && Convert.ToInt32(value) <= FormMain.VirtScreenWidth && Convert.ToInt32(value) >= FormMain.MIN_WIDTH)
                {
                    return ((int)value).ToString();
                }
                else
                {
                    value = "Invalid value! Max is " + FormMain.VirtScreenWidth.ToString() + "px, min - " + FormMain.MIN_WIDTH.ToString();
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

        }

        public class ResHeightConverter : Int16Converter
        {
            public override object ConvertTo(ITypeDescriptorContext context,
                CultureInfo culture, object value, Type destinationType)
            {
                if (destinationType == typeof(string) && value is int && Convert.ToInt32(value) <= FormMain.VirtScreenHeight && Convert.ToInt32(value) >= FormMain.MIN_HEIGHT)
                {
                    return ((int)value).ToString();
                }
                else
                {
                    value = "Invalid value! Max is " + FormMain.VirtScreenHeight.ToString() + "px, min - " + FormMain.MIN_HEIGHT.ToString();
                }
                return base.ConvertTo(context, culture, value, destinationType);
            }

        }

        //FRAME
        public class Frame
        {
            [Category("Frame Settings")]
            [Description("Frame width. Max - screenshot width, min - 16. Default 80.")]
            [DisplayName("Frame Width")]
            public int FrameWidth { get; set; }

            [Category("Frame Settings")]
            [Description("Frame height. Max - screenshot height, min - 16. Default 80.")]
            [DisplayName("Frame Height")]
            public int FrameHeight { get; set; }

            [Category("Frame Settings")]
            [Description("Set frame color.")]
            [DisplayName("Frame Color")]
            public Color Color { get; set; }

        }

        private void FrameSettings()
        {
            Frame frame = new Frame();

            frame.FrameWidth = Convert.ToInt32(FormMain.FrameWidth);
            frame.FrameHeight = Convert.ToInt32(FormMain.FrameHeight);
            frame.Color = FormMain.frameColor;

            pgSettings.SelectedObject = frame;
        }

        //NUMBER
        class Resolutions
        {
            [Category("Size 1")]
            [Description("Size 1 width. Max depends on your monitor resolution. Min - 300px.")]
            [DisplayName("1.1 Width")]
            [TypeConverter(typeof(ResWidthConverter))]
            public int Res1Width
            {
                get;
                set;
            }

            [Category("Size 1")]
            [Description("Size 1 height. Max depends on your monitor resolution. Min - 200px.")]
            [DisplayName("1.2 Height")]
            [TypeConverter(typeof(ResHeightConverter))]
            public int Res1Height
            {
                get;
                set;
            }

            [Category("Size 2")]
            [Description("Size 2 width. Max depends on your monitor resolution. Min - 300px.")]
            [DisplayName("2.1 Width")]
            [TypeConverter(typeof(ResWidthConverter))]
            public int Res2Width
            {
                get;
                set;
            }

            [Category("Size 2")]
            [Description("Size 2 height. Max depends on your monitor resolution. Min - 200px.")]
            [DisplayName("2.2 Height")]
            [TypeConverter(typeof(ResHeightConverter))]
            public int Res2Height
            {
                get;
                set;
            }

            [Category("Size 3")]
            [Description("Size 3 width. Max depends on your monitor resolution. Min - 300px.")]
            [DisplayName("3.1 Width")]
            [TypeConverter(typeof(ResWidthConverter))]
            public int Res3Width
            {
                get;
                set;
            }

            [Category("Size 3")]
            [Description("Size 3 height. Max depends on your monitor resolution. Min - 200px.")]
            [DisplayName("3.2 Height")]
            [TypeConverter(typeof(ResHeightConverter))]
            public int Res3Height
            {
                get;
                set;
            }

            [Category("Size 4")]
            [Description("Size 4 width. Max depends on your monitor resolution. Min - 300px.")]
            [DisplayName("4.1 Width")]
            [TypeConverter(typeof(ResWidthConverter))]
            public int Res4Width
            {
                get;
                set;
            }

            [Category("Size 4")]
            [Description("Size 4 height. Max depends on your monitor resolution. Min - 200px.")]
            [DisplayName("4.2 Height")]
            [TypeConverter(typeof(ResHeightConverter))]
            public int Res4Height
            {
                get;
                set;
            }
        }




        //resolution
        private void ResolutionSettings()
        {
            Resolutions resolutions = new Resolutions();

            resolutions.Res1Width = Convert.ToInt32(FormMain.RES_WORKED[0, 0]);
            resolutions.Res1Height = Convert.ToInt32(FormMain.RES_WORKED[1, 0]);

            resolutions.Res2Width = Convert.ToInt32(FormMain.RES_WORKED[0, 1]);
            resolutions.Res2Height = Convert.ToInt32(FormMain.RES_WORKED[1, 1]);


            resolutions.Res3Width = Convert.ToInt32(FormMain.RES_WORKED[0, 2]);
            resolutions.Res3Height = Convert.ToInt32(FormMain.RES_WORKED[1, 2]);

            resolutions.Res4Width = Convert.ToInt32(FormMain.RES_WORKED[0, 3]);
            resolutions.Res4Height = Convert.ToInt32(FormMain.RES_WORKED[1, 3]);

            pgSettings.SelectedObject = resolutions;
        }

        private int sizeChecker(int inputRes, string resType)
        {

            int finalRes = 0;

            switch (resType)
            {
                case "width":
                    if (inputRes > FormMain.VirtScreenWidth)
                    {
                        finalRes = FormMain.VirtScreenWidth;
                    }
                    else if (inputRes < FormMain.MIN_WIDTH)
                    {
                        finalRes = FormMain.MIN_WIDTH;
                    }
                    else
                    {
                        finalRes = inputRes;
                    }
                    break;
                case "height":
                    if (inputRes > FormMain.VirtScreenHeight)
                    {
                        finalRes = FormMain.VirtScreenHeight;
                    }
                    else if (inputRes < FormMain.MIN_HEIGHT)
                    {
                        finalRes = FormMain.MIN_HEIGHT;
                    }
                    else
                    {
                        finalRes = inputRes;
                    }
                    break;
                default:
                    break;
            }

            return finalRes;
        }


        private void lboxSetCat_Click(object sender, EventArgs e)
        {
            int selCat = lboxSetCat.SelectedIndex;

            GridItem gi = pgSettings.SelectedGridItem;

            while (gi.Parent != null)
            {
                gi = gi.Parent;
            }
            foreach (GridItem item in gi.GridItems)
            {
                ParseGridItems(item); //recursive
            }

            switch (selCat)
            {
                case 0:
                    ArrowSettings();
                    break;
                case 1:
                    FrameSettings();
                    break;
                case 2:
                    GridSettings();
                    break;
                case 3:
                    NumbersSettings();
                    break;
                case 4:
                    ResolutionSettings();
                    break;
                default:
                    break;
            }
        }



        private Color stringToColor(string value)
        {

            Match selGridColor = Regex.Match(value, @"A=(?<Alpha>\d+),\s*R=(?<Red>\d+),\s*G=(?<Green>\d+),\s*B=(?<Blue>\d+)");

            if (selGridColor.Success)
            {
                int alpha = int.Parse(selGridColor.Groups["Alpha"].Value);
                int red = int.Parse(selGridColor.Groups["Red"].Value);
                int green = int.Parse(selGridColor.Groups["Green"].Value);
                int blue = int.Parse(selGridColor.Groups["Blue"].Value);
                Color tempGridColor = Color.FromArgb(alpha, red, green, blue);

                return tempGridColor;
            }
            else
            {
                int nameStart = value.IndexOf("[") + "[".Length;
                int nameEnd = value.LastIndexOf("]");
                String colorNameExtract = value.Substring(nameStart, nameEnd - nameStart);

                Color tempGridColor = Color.FromName(colorNameExtract);
                return tempGridColor;
            }

        }


        private void pgSettings_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {

            object selValue = pgSettings.SelectedGridItem.Value; // changed value

            string selLabel = pgSettings.SelectedGridItem.Label;

            if (selLabel != null && selLabel == "Lock Padding")
            {
                if (selValue.ToString() == "True")
                {
                    lockPadding = true;
                }
                if (selValue.ToString() == "False")
                {
                    lockPadding = false;
                }
            }
        }

  
    }
}
