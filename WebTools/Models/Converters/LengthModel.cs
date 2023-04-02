namespace WebTools.Models.Converters
{
  using System;
  using System.ComponentModel.DataAnnotations;
  using static LengthConstants;

  public class LengthModel
  {
    private double _centimeter;
    private int _foot;
    private double _inch;
    private double _totalTotalFoot;
    private double _totalTotalInch;

    [Key]
    public double Centimeter
    {
      get => _centimeter;
      set
      {
        if (_centimeter != value)
        {
          _centimeter = value;
          OnCentimeterChanged();
        }
      }
    }
    
    public int Foot
    {
      get => _foot;
      set
      {
        if (_foot != value)
        {
          _foot = value;
          OnFootChanged();
        }
      }
    }

    public double Inch
    {
      get => _inch;
      set
      {
        if (_inch != value)
        {
          _inch = value;
          OnInchChanged();
        }
      }
    }
    
    public double TotalFoot
    {
      get => _totalTotalFoot;
      set
      {
        if (_totalTotalFoot != value)
        {
          _totalTotalFoot = value;
          OnFootOnlyChanged();
        }
      }
    }
    
    public double TotalInch
    {
      get => _totalTotalInch;
      set
      {
        if (_totalTotalInch != value)
        {
          _totalTotalInch = value;
          OnInchOnlyChanged();
        }
      }
    }

    private void OnCentimeterChanged()
    {
      _totalTotalFoot = _centimeter * CentimeterToFoot;
      _totalTotalInch = _centimeter * CentimeterToInch;
      CalculateFootAndInch();
    }

    private void OnFootOnlyChanged()
    {
      _centimeter = _totalTotalFoot / CentimeterToFoot;
      _totalTotalInch = _totalTotalFoot * FootToInch;
      CalculateFootAndInch();
    }

    private void OnInchOnlyChanged()
    {
      _centimeter = _totalTotalInch / CentimeterToInch;
      _totalTotalFoot = _totalTotalInch / FootToInch;
      CalculateFootAndInch();
    }
    
    private void CalculateFootAndInch()
    {
      var foot = _totalTotalInch / FootToInch;
      _foot = (int)Math.Floor(foot);
      _inch = _totalTotalInch - _foot * FootToInch;
    }

    private void OnFootChanged()
    {
      OnFootAndInchChanged();
    }
    
    private void OnInchChanged()
    {
      OnFootAndInchChanged();
    }

    private void OnFootAndInchChanged()
    {
      _totalTotalFoot = _foot + _inch / FootToInch;
      _totalTotalInch = _foot * FootToInch + _inch;
      _centimeter = _totalTotalFoot / CentimeterToFoot;
    }
  }
}