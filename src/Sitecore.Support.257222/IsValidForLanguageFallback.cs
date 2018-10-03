using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.LanguageFallback;
using Sitecore.Pipelines.GetFieldValue;

namespace Sitecore.Support.Pipelines.GetFieldValue.IsValidForLanguageFallback
{
  public class IsValidForLanguageFallback
  {
    public void Process(GetFieldValueArgs args)
    {
      if (args.AllowFallbackValue)
      {
        args.IsValidForLanguageFallback = !IsUiStatic(args.Field);

        if (args.IsValidForLanguageFallback)
        {
          args.IsValidForLanguageFallback = LanguageFallbackFieldValuesManager.IsValidForFallback(args.Field);
        }
      }
    }

    private bool IsUiStatic(Field field)
    {
      return field.ID == FieldIDs.UIStaticItem;
    }
  }
}