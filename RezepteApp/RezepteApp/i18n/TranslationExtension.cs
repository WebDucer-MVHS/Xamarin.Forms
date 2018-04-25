using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RezepteApp.i18n
{
    [ContentProperty(nameof(Key))]
    public class TranslationExtension : IMarkupExtension
    {
        public string Key { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Key))
            {
                return string.Empty;
            }

            var translation = AppResources.ResourceManager.GetString(Key);

            if (translation == null)
            {
#if DEBUG
                translation = $"[_{Key}_]";
#else
                translation = Key;
#endif
            }

            return translation;
        }
    }
}
