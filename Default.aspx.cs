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
    const string RESULTS_OF = "Result {0} of {1}";
    int current;
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
        if (String.IsNullOrEmpty(tbSearch.Text))
        {
            ReturnNoneFound("Please enter more search terms.");
            return;
        }

        searchTerms = tbSearch.Text.Split(' ').Except(excludedTerms).ToArray();
        if (searchTerms.Length == 0)
        {
            ReturnNoneFound("Please enter more search terms.");
            return;
        }

        resultFiles = SearchForFiles();
        if (resultFiles.Length == 0)
        {
            ReturnNoneFound();
            return;
        }
        else
        {
            current = 0;
            UpdateForm();
        }
    }

    protected void ibFirst_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ibPrevious_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ibNext_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ibLast_Click(object sender, ImageClickEventArgs e)
    {

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
        string content = File.ReadAllText(dir + "exclusion/exclusion.txt");
        excludedTerms = content.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Formatter for web form when no results are found.
    /// </summary>
    /// <param name="str">Displays message in text area.</param>
    private void ReturnNoneFound(string str = "")
    {
        tbResultsNum.Text = NO_RESULTS;
        tbFilename.Text = "";
        taResult.Text = str;
    }

    /// <summary>
    /// Searches through the .txt files in ./files using the search query.
    /// </summary>
    /// <returns>Array of filepaths to files containg search terms.</returns>
    private string[] SearchForFiles()
    {
        List<string> files = new List<string>();
        for (int i = 0; i < readFromFiles.Length; i++)
        {
            string content = GetContents(readFromFiles[i]);
            for (int j = 0; j < searchTerms.Length; j++)
            {
                if (content.Contains(searchTerms[j]))
                {
                    files.Add(readFromFiles[i]);
                }
            }
        }

        return files.ToArray();
    }

    /// <summary>
    /// Updates web form with single result from search.
    /// </summary>
    private void UpdateForm()
    {
        string currentPosition = Convert.ToString(current + 1);
        string lastPosition = Convert.ToString(resultFiles.Length);
        tbFilename.Text = Path.GetFileName(resultFiles[current]);
        tbResultsNum.Text = RESULTS_OF.Replace("{0}", currentPosition).Replace("{1}", lastPosition);
        taResult.Text = GetContents(resultFiles[current]);
    }

    /// <summary>
    /// Returns the content of a text file.
    /// </summary>
    /// <param name="filepath">Filepath to file to be opened.</param>
    /// <returns>Content of text file.</returns>
    private string GetContents(string filepath)
    {
        string content;
        content = File.ReadAllText(filepath);
        return content;
    }

}
