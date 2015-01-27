using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    string dir;
    string[] allFiles,
             searchTerms,
             resultFiles;

    /// <summary>
    /// Runs on first page load.
    /// Adds jQuery.
    /// Identify and locate all files in files directory.
    /// </summary>
    /// <param name="sender">The sender of the message.</param>
    /// <param name="e">The arguments of the message.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        InitJquery();
        dir = MapPath("./files");
        allFiles = Directory.GetFiles(dir, "*.txt");
    }

    /// <summary>
    /// Launches the search for the user.
    /// </summary>
    /// <param name="sender">The sender of the message.</param>
    /// <param name="e">The arguments of the message.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(tbSearch.Text))
        {
            searchTerms = tbSearch.Text.Split(new Char[] { ' ' });
        }
    }

    /// <summary>
    /// Initializes jQuery for the Required Field Validation.
    /// Source: https://msdn.microsoft.com/en-us/library/system.web.ui.scriptmanager.scriptresourcemapping%28v=vs.110%29.aspx
    /// </summary>
    private void InitJquery()
    {
        ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
        myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
        myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
        myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
        myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
    }

}
