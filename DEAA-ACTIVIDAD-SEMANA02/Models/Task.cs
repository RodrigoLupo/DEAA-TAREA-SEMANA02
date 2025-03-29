namespace DEAA_ACTIVIDAD_SEMANA02.Models;

public class Task
{
    public int Id { get; set; }  
    public string Title { get; set; }  
    public string Status { get; set; }  
    public DateTime  StartDate { get; set; }
    public DateTime  EndDate { get; set; }
}