using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MyRadio.Models;

public class RadioTypeViewModel
{
    public List<Radio>? Radios { get; set; }
    public SelectList? TypeofRadio { get; set; }
    public string? TypeOfRadio { get; set; }
    public string? SearchString { get; set; }
}
