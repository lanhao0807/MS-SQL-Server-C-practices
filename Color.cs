public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    public Color(int red, int green, int blue, int alpha)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }

    public Color(int red, int green, int blue) : this(red, green, blue, 255){}

    public int GetRed()
    {
        return red;
    }

    public void SetRed(int red)
    {
        this.red = red;
    }

    public int GetGreen()
    {
        return green;
    }

    public void SetGreen(int green)
    {
        this.green = green;
    }

    public int GetBlue()
    {
        return blue;
    }

    public void SetBlue(int blue)
    {
        this.blue = blue;
    }

    public int GetAlpha()
    {
        return alpha;
    }

    public void SetAlpha(int alpha)
    {
        this.alpha = alpha;
    }

    public int GetGrayscale()
    {
        return (red + green + blue) / 3;
    }
}
