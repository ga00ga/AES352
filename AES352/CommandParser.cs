using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

public class CommandParser
{
    private TextBox codeTextBox;
    private PictureBox displayArea;
    private Graphics graphics;
    private Pen currentPen;
    private PointF currentPosition;

    public CommandParser(TextBox codeTextBox, PictureBox displayArea)
    {
        this.codeTextBox = codeTextBox;
        this.displayArea = displayArea;
        this.graphics = displayArea.CreateGraphics();
        this.currentPen = new Pen(Color.Black); 
        this.currentPosition = new PointF(0, 0); 
    }

    public void ExecuteCommand(string command)
    {
        var parts = command.Split(' ');
        switch (parts[0].ToLower())
        {
            case "moveto":
                MoveTo(float.Parse(parts[1]), float.Parse(parts[2]));
                break;
            case "drawto":
                DrawTo(float.Parse(parts[1]), float.Parse(parts[2]));
                break;
            case "clear":
                Clear();
                break;
            case "rectangle":
                DrawRectangle(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]), float.Parse(parts[4]));
                break;
            case "circle":
                DrawCircle(float.Parse(parts[1]));
                break;
            case "triangle":
                DrawTriangle(float.Parse(parts[1]), float.Parse(parts[2]), float.Parse(parts[3]), float.Parse(parts[4]), float.Parse(parts[5]), float.Parse(parts[6]));
                break;
            case "color":
                SetColor(Color.FromName(parts[1]));
                break;
            default:
                throw new ArgumentException("Unknown command");
        }
    }

    public void ExecuteProgram()
    {
        var commands = codeTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var command in commands)
        {
            ExecuteCommand(command.Trim());
        }
    }

    public void SaveProgram(string filePath)
    {
        File.WriteAllText(filePath, codeTextBox.Text);
    }

    public void LoadProgram(string filePath)
    {
        codeTextBox.Text = File.ReadAllText(filePath);
    }

    public void CheckSyntax()
    {
        var commands = codeTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var command in commands)
        {
            if (!IsValidCommand(command))
            {
                MessageBox.Show($"Syntax error in command: {command}", "Syntax Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        MessageBox.Show("Syntax is correct!", "Syntax Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private bool IsValidCommand(string command)
    {
        // TODO: Implement the actual syntax validation logic for your commands
        // This is just a placeholder and should be replaced with actual validation logic
        return true;
    }

    private void MoveTo(float x, float y)
    {
        currentPosition = new PointF(x, y);
    }

    private void DrawTo(float x, float y)
    {
        PointF newPosition = new PointF(x, y);
        graphics.DrawLine(currentPen, currentPosition, newPosition);
        currentPosition = newPosition;
    }

    private void Clear()
    {
        graphics.Clear(displayArea.BackColor);
    }

    private void DrawRectangle(float x, float y, float width, float height)
    {
        graphics.DrawRectangle(currentPen, x, y, width, height);
    }

    private void DrawCircle(float radius)
    {
        graphics.DrawEllipse(currentPen, currentPosition.X - radius, currentPosition.Y - radius, radius * 2, radius * 2);
    }

    private void DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3)
    {
        PointF[] points = { new PointF(x1, y1), new PointF(x2, y2), new PointF(x3, y3) };
        graphics.DrawPolygon(currentPen, points);
    }

    private void SetColor(Color color)
    {
        currentPen.Color = color;
    }

    // Call this method when the form is closing or you need to release resources
    public void Cleanup()
    {
        graphics.Dispose();
        currentPen.Dispose();
    }
}
