namespace PolicyModels
{
    public class InsurancePolicy
    {
        public string NumeroPoliza { get; set; }
        public string NombreCliente { get; set; }
        public string IdentificacionCliente { get; set; }
        public DateTime FechaNacimientoCliente { get; set; }
        public DateTime FechaPoliza { get; set; }
        public string CoberturasPoliza { get; set; }
        public decimal ValorCubiertoPoliza { get; set; }
        public string NombrePoliza { get; set; }
        public string CiudadCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string PlacaVehiculo { get; set; }
        public string ModeloVehiculo { get; set; }
        public bool VehiculoConInspeccion { get; set; }
    }
}