using System;
using System.Windows.Forms;
using System.Reflection;

namespace TuppersFormula
{
    public static class TextBoxExtensions
    {
        private static readonly FieldInfo _field;
        private static readonly PropertyInfo _prop;

        static TextBoxExtensions()
        {
            Type type = typeof(Control);
            _field = type.GetField("text", BindingFlags.Instance | BindingFlags.NonPublic);
            _prop = type.GetProperty("WindowText", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public static void SetText(this TextBox box, string text)
        {
            _field.SetValue(box, text);
            _prop.SetValue(box, text, null);
        }
    }
}
