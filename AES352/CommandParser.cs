using System;
using System.IO;
using System.Windows.Forms;

public class CommandParser
{
    private TextBox codeTextBox;
    private PictureBox displayArea;

    public CommandParser(TextBox codeTextBox, PictureBox displayArea)
    {
        this.codeTextBox = codeTextBox;
        this.displayArea = displayArea;
    }

    // to execute one command
    public void ExecuteCommand(string command)
    {
        // TODO: Implement the logic to parse and execute a single command
    }

    // executes a multiple commands from the codeTextBox
    public void ExecuteProgram()
    {
        var commands = codeTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var command in commands)
        {
            ExecuteCommand(command.Trim());
        }
    }

    // Saves the current program in the codeTextBox to a file
    public void SaveProgram(string filePath)
    {
        File.WriteAllText(filePath, codeTextBox.Text);
    }

    // Loads a program from a file into the codeTextBox
    public void LoadProgram(string filePath)
    {
        codeTextBox.Text = File.ReadAllText(filePath);
    }

    // Checks the syntax of the current program in the codeTextBox
    public void CheckSyntax()
    {
        var commands = codeTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var command in commands)
        {
            // TODO: Implement the logic to check the syntax of a command
        }
        MessageBox.Show("Syntax is correct!", "Syntax Check", MessageBoxButtons.OK, MessageBoxIcon.Information); //if syntax isnt wrong
    }

    // Validates if a command is syntactically correct
    private bool IsValidCommand(string command)
    {
        // TODO: Implement the actual syntax validation logic for your commands
        return true; // assume all commands are valid for now
    }
}
