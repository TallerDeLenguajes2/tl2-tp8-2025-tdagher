public class Presupuestos
{

    public int IdPresupuesto { get; set; }
    public string NombreDestinatario { get; set; }
    public DateTime FechaCreacion { get; set; }
    public List<PresupuestoDetalle> detalle { get; set; } = new List<PresupuestoDetalle>();

    public decimal MontoPresupuesto()
    {
        decimal presupuesto = 0;//TODO crear como conseguir el presupuesto
        return presupuesto;
    }

    public decimal MontoPresupuestoConIva()
    {
        decimal montoBase = MontoPresupuesto();
        const decimal IVA = 1.21m;
        return montoBase * IVA;
    }

    public int CantidadProductos()
    {
        return detalle.Sum(d => d.Cantidad);
    }
}