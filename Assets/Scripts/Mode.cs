public class Mode
{
    public delegate double ModeMethod(double resistance, double power);

    public string name;
    private ModeMethod modeMethod;

    //public Mode(ModeMethod modeMethod)
    //{
    //    this.modeMethod = modeMethod;
    //}
    public Mode(string name, ModeMethod modeMethod)
    {
        this.name = name;
        this.modeMethod = modeMethod;
    }

    public double GetValue(double resistance = 0, double power = 0)
    {
        return modeMethod(resistance, power);
    }
}
