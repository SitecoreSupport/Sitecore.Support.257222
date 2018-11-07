using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.LanguageFallback;
using Sitecore.Pipelines.GetFieldValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.Pipelines.GetFieldValue
{
  public class IsValidForLanguageFallback
  {
    public void Process(GetFieldValueArgs args)
    {
      if (args.AllowFallbackValue)
      {
        if (!IsUiStatic(args.Field) && !IsOldLayout(args.Field))
        {
          args.IsValidForLanguageFallback = LanguageFallbackFieldValuesManager.IsValidForFallback(args.Field);
        }
      }
    }

    private bool IsUiStatic(Field field)
    {
      return field.ID == FieldIDs.UIStaticItem;
    }

    // Fix for oldlayout fields
    private bool IsOldLayout(Field field)
    {
      return field.ID == new ID("{E1D68787-D22B-4EA2-82B3-84C282E375EB}");
    }
  }
}