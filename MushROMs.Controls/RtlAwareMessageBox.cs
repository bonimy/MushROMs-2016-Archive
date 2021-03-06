﻿/* Taken from:
 * http://msdn.microsoft.com/query/dev12.query?appId=Dev12IDEF1&l=EN-US&k=k%28CA1300%29;k%28TargetFrameworkMoniker-.NETFramework
 * */

using System.Globalization;
using System.Windows.Forms;

namespace MushROMs.Controls
{
    public static class RtlAwareMessageBox
    {
        public static DialogResult Show(string text)
        {
            return Show(null, text, System.String.Empty);
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            return Show(owner, text, System.String.Empty);
        }

        public static DialogResult Show(string text, string caption)
        {
            return Show(null, text, caption);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            return Show(owner, text, caption, MessageBoxButtons.OK);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            return Show(null, text, caption, buttons);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            return Show(owner, text, caption, buttons, MessageBoxIcon.None);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(null, text, caption, buttons, icon);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return Show(owner, text, caption, buttons, icon, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(null, text, caption, buttons, icon, defaultButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(owner, text, caption, buttons, icon, defaultButton, 0);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return Show(null, text, caption, buttons, icon, defaultButton, options);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(owner, options));
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, bool displayHelpButton)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(null, options), displayHelpButton);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(null, options), helpFilePath);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(owner, options), helpFilePath);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(null, options), helpFilePath, keyword);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, string keyword)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(owner, options), helpFilePath, keyword);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(null, options), helpFilePath, navigator);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(owner, options), helpFilePath, navigator);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
        {
            return MessageBox.Show(text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(null, options), helpFilePath, navigator, param);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, string helpFilePath, HelpNavigator navigator, object param)
        {
            return MessageBox.Show(owner, text, caption, buttons, icon, defaultButton, RightToLeftAwareOptions(owner, options), helpFilePath, navigator, param);
        }

        public static MessageBoxOptions RightToLeftAwareOptions(IWin32Window owner, MessageBoxOptions options)
        {
            if (IsRightToLeft(owner))
            {
                return options | MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign;
            }

            return options;
        }

        public static bool IsRightToLeft(IWin32Window owner)
        {
            if (owner == null)
            {
                return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
            }

            return Control.FromHandle(owner.Handle).RightToLeft == RightToLeft.Yes;
        }
    }
}
