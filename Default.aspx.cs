using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    const string NO_RESULTS = "No results found.";
    string dir;
    string[] excludedTerms,
             readFromFiles,
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
        InitFiles();
        InitTerms();
    }

    /// <summary>
    /// Launches the search for the user.
    /// </summary>
    /// <param name="sender">The sender of the message.</param>
    /// <param name="e">The arguments of the message.</param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(tbSearch.Text) || readFromFiles.Length == 0)
        {
            tbResultsNum.Text = NO_RESULTS;
            resultFiles = new string[] {};
        }
        else
        {
            searchTerms = tbSearch.Text.Split(new Char[] { ' ' }).Except(excludedTerms).ToArray();
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

    /// <summary>
    /// Initializes files variables.
    /// </summary>
    private void InitFiles()
    {
        dir = MapPath("./");
        readFromFiles = Directory.GetFiles(dir + "files", "*.txt");
    }

    /// <summary>
    /// Initialize excluded terms array.
    /// </summary>
    private void InitTerms()
    {
        StreamReader reader = new StreamReader(dir + "exclusion/exclusion.txt");
        string content = reader.ReadToEnd();
        excludedTerms = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }

}
