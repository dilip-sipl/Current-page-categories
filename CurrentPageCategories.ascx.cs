using CMS.Helpers;
using CMS.PortalEngine.Web.UI;
using System;

public partial class CMSWebParts_CurrentPageCategories : CMSAbstractWebPart
{
    #region "Webpart Categories"
    /// <summary>
    /// Categroy Separator for the document categories
    /// </summary>
    public string CategroySeparator
    {
        get
        {
            return ValidationHelper.GetString(GetValue("CategroySeparator"), "");
        }
        set
        {
            SetValue("CategroySeparator", value);
        }
    }

    #endregion "Webpart Categories"

    #region "Event handlers"

    /// <summary>
    /// Content loaded event handler.
    /// </summary>
    public override void OnContentLoaded()
    {
        base.OnContentLoaded();
        SetupControl();
    }


    /// <summary>
    /// Reload date override.
    /// </summary>
    public override void ReloadData()
    {
        base.ReloadData();
        SetupControl();
    }

    /// <summary>
    /// Sets up the inner child controls.
    /// </summary>
    private void SetupControl()
    {
        string categorieNames = "";

        // Gets the categroies of current document
        if (CurrentDocument.Categories != null && CurrentDocument.Categories.Count > 0)
        {
            int i = 0;

            var documentCategoryNames = CurrentDocument.Categories.DisplayNames;
            foreach (var categoryName in documentCategoryNames)
            {
                // Addes the category separator after each category name
                if (!string.IsNullOrEmpty(CategroySeparator) && i > 0)
                    categorieNames += CategroySeparator;

                categorieNames += categoryName.Value;
                i++;
            }

            ltrDisplayCategories.Text = categorieNames;
        }
    }

    #endregion "Event handlers"
}