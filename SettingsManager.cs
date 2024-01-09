using System.Configuration;
using System.Reflection.Metadata.Ecma335;


namespace screener3

{
    internal class SettingsManager
    {
        public static string[] tempStringArray = new string[] { "" };

        public static bool DrawGridConfigValue,
            DrawArrowConfigValue,
            DrawNumberConfigValue,
            DrawFrameConfigValue,
            SaveFileConfigValue;

        private static void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection(configuration.AppSettings.SectionInformation.Name);

        }

        public static void SaveConfig(int ClientWidth, int ClientHeight)
        {
            SetSetting("guidlines_color", ColorTranslator.ToHtml(FormMain.gridColor)); //COLOR
            SetSetting("arrow_color", ColorTranslator.ToHtml(FormMain.arrowColor));
            SetSetting("number_color", ColorTranslator.ToHtml(FormMain.numberColor));
            SetSetting("frame_color", ColorTranslator.ToHtml(FormMain.frameColor));

            SetSetting("guidline_type", FormMain.GridType.ToString());
            SetSetting("arrows_type", FormMain.ArrowType.ToString());
            SetSetting("arrow_lenght", FormMain.arrowLenght.ToString());
            SetSetting("number_size", FormMain.numberFontSize.ToString());

            SetSetting("draw_guidlines", FormMain.drawGrid.ToString().ToLower());
            SetSetting("draw_arrows", FormMain.drawArrows.ToString().ToLower());
            SetSetting("draw_number", FormMain.drawNumber.ToString().ToLower());
            SetSetting("save_to_file", FormMain.saveToFile.ToString().ToLower());

            SetSetting("draw_frame", FormMain.drawFrame.ToString().ToLower());
            
            SetSetting("frame_width", FormMain.FrameWidth.ToString());
            SetSetting("frame_height", FormMain.FrameHeight.ToString());


            for (int i = 1; i < 5; i++)
            {
                SetSetting("resolution_" + i.ToString(), FormMain.RES_WORKED[0, i - 1] + "," + FormMain.RES_WORKED[1, i - 1]);
            }

            SetSetting("res_on_close", ClientWidth.ToString() + "," + ClientHeight.ToString());

            SetSetting("custom_grid", FormMain.CUSTOM_GRID[0].ToString() + "," + FormMain.CUSTOM_GRID[1].ToString() + "," + FormMain.CUSTOM_GRID[2].ToString() + "," + FormMain.CUSTOM_GRID[3].ToString());

            SetSetting("ident_value_lock", FormMain.indentValueLock.ToString().ToLower());
        }


        public static void LoadSettings()
        {
            //temp value for read
            string tempValueFromConfig;

            //add resolution
            for (int i = 1; i < 5; i++)
            {
                tempValueFromConfig = ConfigurationManager.AppSettings["resolution_" + i.ToString()];
                tempStringArray = tempValueFromConfig.Split(",");

                try
                {
                    FormMain.RES_WORKED[0, i - 1] = int.Parse(tempStringArray[0]);
                }
                catch
                {
                    FormMain.RES_WORKED[0, i - 1] = FormMain.RES_DEFAULT[0, i - 1];
                }

                try
                {
                    FormMain.RES_WORKED[1, i - 1] = int.Parse(tempStringArray[1]);
                }
                catch
                {
                    FormMain.RES_WORKED[1, i - 1] = FormMain.RES_DEFAULT[1, i - 1];
                }
            }
  
            //resolution on close
            tempValueFromConfig = ConfigurationManager.AppSettings["res_on_close"];
            tempStringArray = tempValueFromConfig.Split(",");

            // Set client size
            try
            {
                FormMain.StartResW = Convert.ToInt32(tempStringArray[0]); //set width
                FormMain.StartResH = Convert.ToInt32(tempStringArray[1]); //set height
            }
            catch
            {
                FormMain.StartResW = Convert.ToInt32(FormMain.RES_WORKED[0, 0]);
                FormMain.StartResH = Convert.ToInt32(FormMain.RES_WORKED[1, 0]);               
            }

            //Grid COLOR
            tempValueFromConfig = ConfigurationManager.AppSettings["guidlines_color"];
            try
            {
                FormMain.gridColor = ColorTranslator.FromHtml(tempValueFromConfig);
            }
            catch
            {
                FormMain.gridColor = Color.FromName(tempValueFromConfig);
            }

            //Arrow COLOR
            tempValueFromConfig = ConfigurationManager.AppSettings["arrow_color"];
            FormMain.arrowColor = ColorTranslator.FromHtml(tempValueFromConfig);

            //Number COLOR
            tempValueFromConfig = ConfigurationManager.AppSettings["number_color"];
            FormMain.numberColor = ColorTranslator.FromHtml(tempValueFromConfig);


            try
            {
                tempValueFromConfig = ConfigurationManager.AppSettings["number_size"];
                FormMain.numberFontSize = int.Parse(tempValueFromConfig);
            }
            catch
            {
                FormMain.numberFontSize = 1;
            }

            try
            {
                tempValueFromConfig = ConfigurationManager.AppSettings["guidline_type"];
                FormMain.GridType = int.Parse(tempValueFromConfig);
            }
            catch
            {
                FormMain.GridType = 1;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["draw_guidlines"];
            FormMain.drawGrid = Convert.ToBoolean(tempValueFromConfig);

            if (FormMain.drawGrid)
            {
                DrawGridConfigValue = true;
            }
            else
            {
                DrawGridConfigValue = false;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["draw_arrows"];
            FormMain.drawArrows = Convert.ToBoolean(tempValueFromConfig);


            if (FormMain.drawArrows)
            {
                DrawArrowConfigValue = true;
            }
            else
            {
                DrawArrowConfigValue = false;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["draw_number"];
            FormMain.drawNumber = Convert.ToBoolean(tempValueFromConfig);

            if (FormMain.drawNumber)
            {
                DrawNumberConfigValue = true;
            }
            else
            {
                DrawNumberConfigValue = false;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["arrows_type"];
            try
            {
                FormMain.ArrowType = int.Parse(tempValueFromConfig);
            }
            catch
            {

                FormMain.ArrowType = 1;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["arrow_lenght"];
            try
            {
                FormMain.arrowLenght = int.Parse(tempValueFromConfig);
            }
            catch
            {
                FormMain.arrowLenght = 50;
            }

            //resolution on close
            tempValueFromConfig = ConfigurationManager.AppSettings["custom_grid"];
            tempStringArray = tempValueFromConfig.Split(",");

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    FormMain.CUSTOM_GRID[i] = int.Parse(tempStringArray[i]);
                }
                catch
                {
                    FormMain.CUSTOM_GRID[i] = 10;
                }

            }

            tempValueFromConfig = ConfigurationManager.AppSettings["ident_value_lock"];
            FormMain.indentValueLock = Convert.ToBoolean(tempValueFromConfig);

            tempValueFromConfig = ConfigurationManager.AppSettings["save_to_file"];
            FormMain.saveToFile = Convert.ToBoolean(tempValueFromConfig);

            if (FormMain.saveToFile)
            {
                SaveFileConfigValue = true;
            }
            else
            {
                SaveFileConfigValue = false;
            }


            tempValueFromConfig = ConfigurationManager.AppSettings["draw_frame"];
            FormMain.drawFrame = Convert.ToBoolean(tempValueFromConfig);

            if (FormMain.drawFrame)
            {
                DrawFrameConfigValue = true;
            }
            else
            {
                DrawFrameConfigValue = false;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["frame_width"];
            try
            {
                FormMain.FrameWidth = int.Parse(tempValueFromConfig);
            }
            catch
            {
                FormMain.FrameWidth = 64;
            }

            tempValueFromConfig = ConfigurationManager.AppSettings["frame_height"];

            try
            {
                FormMain.FrameHeight = int.Parse(tempValueFromConfig);
            }
            catch
            {
                FormMain.FrameHeight = 64;
            }


            //Frame COLOR
            tempValueFromConfig = ConfigurationManager.AppSettings["frame_color"];
            FormMain.frameColor = ColorTranslator.FromHtml(tempValueFromConfig);
        }

       

    }
}
