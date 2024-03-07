﻿using System.Windows;
using System.Windows.Forms;
using VACM.NET4_0.ViewModels.Accessors;

namespace VACM.NET4_0.Extensions
{
    /// <summary>
    /// Wrapper for MessageBox library.
    /// </summary>
    public class MessageBoxWrapper
    {
        private readonly static string errorCaption = "Error";
        private readonly static string noticeCaption = "Notice";
        private readonly static string warningCaption = "Warning";

        /// <summary>
        /// Return True if question is answered with Yes.
        /// False if No.
        /// </summary>
        /// <param name="messageBoxText">The message box text</param>
        /// <returns>True/False</returns>
        public static bool ShowYesNoAndReturnTrueFalse(string messageBoxText)
        {
            return MessageBoxExtension.Show(messageBoxText,
                AssemblyInformationAccessor.AssemblyTitle, MessageBoxButtons.YesNo)
                is (DialogResult)MessageBoxResult.Yes;
        }

        /// <summary>
        /// Return True if question is answered with Yes.
        /// False if No.
        /// </summary>
        /// <param name="messageBoxText">The message box text</param>
        /// <param name="messageBoxCaption">The message box caption</param>
        /// <returns>True/False</returns>
        public static bool ShowYesNoAndReturnTrueFalse
            (string messageBoxText, string messageBoxCaption)
        {
            return MessageBoxExtension.Show(messageBoxText, messageBoxCaption,
                MessageBoxButtons.YesNo) is (DialogResult)MessageBoxResult.Yes;
        }

        /// <summary>
        /// Show MessageBox which user must close.
        /// Predefined caption.
        /// </summary>
        /// <param name="messageBoxText">The message box text</param>
        public static void Show(string messageBoxText)
        {
            MessageBoxExtension.Show(messageBoxText,
                AssemblyInformationAccessor.AssemblyTitle);
        }

        /// <summary>
        /// Show MessageBox which user must close.
        /// Predefined caption.
        /// </summary>
        /// <param name="messageBoxText">The message box text</param>
        /// <param name="messageBoxCaption">The message box caption</param>
        public static void Show(string messageBoxText, string messageBoxCaption)
        {
            MessageBoxExtension.Show(messageBoxText, messageBoxCaption);
        }

        /// <summary>
        /// Show MessageBox with predefined caption "Error".
        /// </summary>
        /// <param name="messageBoxText">The message box text</param>
        public static void ShowError(string messageBoxText)
        {
            MessageBoxExtension.Show(messageBoxText, errorCaption);
        }

        /// <summary>
        /// Show MessageBox with predefined caption "Notice".
        /// </summary>
        /// <param name="messageBoxText">The message box text</param>
        public static void ShowNotice(string messageBoxText)
        {
            MessageBoxExtension.Show(messageBoxText, noticeCaption);
        }

        /// <summary>
        /// Show MessageBox with predefined caption "Warning".
        /// </summary>
        /// <param name="messageBoxText">The message box text</param>
        public static void ShowWarning(string messageBoxText)
        {
            MessageBoxExtension.Show(messageBoxText, warningCaption);
        }
    }
}