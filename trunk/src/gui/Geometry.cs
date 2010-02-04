using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CAE.src.gui
{
    /// <summary>
    /// Manages the geometry of a window form.  Stores and restores
    /// geometry from the Settings.settings file.
    /// 
    /// Code From: http://www.codeproject.com/KB/dialog/restoreposition.aspx
    /// License: http://www.codeproject.com/info/cpol10.aspx
    /// </summary>
    class Geometry
    {
        /// <summary>
        /// Restore the geometry of a window from a string.
        /// </summary>
        /// <param name="thisWindowGeometry">The string value containing the geometry of the window.</param>
        /// <param name="formIn">The form to restore size and position to.</param>
        public static void GeometryFromString(string thisWindowGeometry, Form formIn)
        {
            if (string.IsNullOrEmpty(thisWindowGeometry) == true)
            {
                return;
            }
            string[] numbers = thisWindowGeometry.Split('|');
            string windowString = numbers[4];
            if (windowString == "Normal")
            {
                Point windowPoint = new Point(int.Parse(numbers[0]),
                    int.Parse(numbers[1]));
                Size windowSize = new Size(int.Parse(numbers[2]),
                    int.Parse(numbers[3]));

                bool locOkay = GeometryIsBizarreLocation(windowPoint, windowSize);
                bool sizeOkay = GeometryIsBizarreSize(windowSize);

                if (locOkay == true && sizeOkay == true)
                {
                    formIn.Location = windowPoint;
                    formIn.Size = windowSize;
                    formIn.StartPosition = FormStartPosition.Manual;
                    formIn.WindowState = FormWindowState.Normal;
                }
                else if (sizeOkay == true)
                {
                    formIn.Size = windowSize;
                }
            }
            else if (windowString == "Maximized")
            {
                formIn.Location = new Point(100, 100);
                formIn.StartPosition = FormStartPosition.Manual;
                formIn.WindowState = FormWindowState.Maximized;
            }
        }

        /// <summary>
        /// Check to see if the location of the window is an okay place to
        /// perform the restore.
        /// </summary>
        /// <param name="loc">The location of the upper-left corner.</param>
        /// <param name="size">The size of the window.</param>
        /// <returns>True if the location is okay.</returns>
        private static bool GeometryIsBizarreLocation(Point loc, Size size)
        {
            bool locOkay;
            if (loc.X < 0 || loc.Y < 0)
            {
                locOkay = false;
            }
            else if (loc.X + size.Width > Screen.PrimaryScreen.WorkingArea.Width)
            {
                locOkay = false;
            }
            else if (loc.Y + size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                locOkay = false;
            }
            else
            {
                locOkay = true;
            }
            return locOkay;
        }

        /// <summary>
        /// Check to make sure that the window is not bigger than the size
        /// of the screen.
        /// </summary>
        /// <param name="size">The size of the form being restored.</param>
        /// <returns>True if the size is okay.</returns>
        private static bool GeometryIsBizarreSize(Size size)
        {
            return (size.Height <= Screen.PrimaryScreen.WorkingArea.Height &&
                size.Width <= Screen.PrimaryScreen.WorkingArea.Width);
        }

        /// <summary>
        /// Provides the means for persisting the geometry of a form.
        /// </summary>
        /// <param name="mainForm">The form to persist the size and location for.</param>
        /// <returns>The string that represents the size and location.  This can then be stored.</returns>
        public static string GeometryToString(Form mainForm)
        {
            return mainForm.Location.X.ToString() + "|" +
                mainForm.Location.Y.ToString() + "|" +
                mainForm.Size.Width.ToString() + "|" +
                mainForm.Size.Height.ToString() + "|" +
                mainForm.WindowState.ToString();
        }
    }
}
