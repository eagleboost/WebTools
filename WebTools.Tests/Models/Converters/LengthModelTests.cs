namespace WebTools.Tests.Models.Converters
{
  using NUnit.Framework;
  using WebTools.Models.Converters;

  public class LengthModelTests
  {
    private const double Tolerance = 0.0000001;

    [Test]
    public void Task_01_Centimeter()
    {
      var model = new LengthModel { Centimeter = 100 };
      Assert.That(model.TotalFoot, Is.EqualTo(3.2808399).Within(Tolerance));
      Assert.That(model.TotalInch, Is.EqualTo(39.370079).Within(Tolerance));
      Assert.That(model.Foot, Is.EqualTo(3).Within(Tolerance));
      Assert.That(model.Inch, Is.EqualTo(3.370079).Within(Tolerance));
    }

    [Test]
    public void Task_02_TotalFoot()
    {
      var model = new LengthModel { TotalFoot = 1.5 };
      Assert.That(model.Centimeter, Is.EqualTo(45.7199985).Within(Tolerance));
      Assert.That(model.TotalInch, Is.EqualTo(18).Within(Tolerance));
      Assert.That(model.Foot, Is.EqualTo(1).Within(Tolerance));
      Assert.That(model.Inch, Is.EqualTo(6).Within(Tolerance));
    }

    [Test]
    public void Task_03_TotalFoot()
    {
      var model = new LengthModel { TotalInch = 18 };
      Assert.That(model.Centimeter, Is.EqualTo(45.71999969).Within(Tolerance));
      Assert.That(model.TotalFoot, Is.EqualTo(1.5).Within(Tolerance));
      Assert.That(model.Foot, Is.EqualTo(1).Within(Tolerance));
      Assert.That(model.Inch, Is.EqualTo(6).Within(Tolerance));
    }


    [Test]
    public void Task_04_FootAndInch()
    {
      var model = new LengthModel { Foot = 1, Inch = 12 };
      Assert.That(model.Centimeter, Is.EqualTo(60.959998).Within(Tolerance));
      Assert.That(model.TotalFoot, Is.EqualTo(2).Within(Tolerance));
      Assert.That(model.TotalInch, Is.EqualTo(24).Within(Tolerance));
    }
  }
}