namespace Bank.Domain
{
    public class CuentaAhorro
    {
        public const string ERROR_MONTO_MENOR_IGUAL_A_CERO = "El monto no puede ser menor o igual a 0";
        public int IdCuenta { get; private set; }
        public string NumeroCuenta { get; private set; }
        public virtual Cliente Propietario { get; private set; }
        public int IdPropietario { get; private set; }
        public decimal Tasa { get; private set; }
        public decimal Saldo { get; private set; }
        public DateTime FechaApertura { get; private set; }
        public bool Estado { get; private set; }

        public CuentaAhorro(string numeroCuenta, Cliente propietario, decimal tasa)
        {
            NumeroCuenta = numeroCuenta ?? string.Empty;
            Propietario = propietario ?? throw new System.ArgumentNullException(nameof(propietario));
            IdPropietario = propietario.IdCliente;
            Tasa = tasa;
            Saldo = 0m;
            FechaApertura = DateTime.UtcNow;
            Estado = true;
        }
        
        public static CuentaAhorro Aperturar(string _numeroCuenta, Cliente _propietario, decimal _tasa)
        {
            return new CuentaAhorro(_numeroCuenta, _propietario, _tasa);
        }     
        public void Depositar(decimal monto)
        {
            if (monto <= 0)
                throw new System.Exception (ERROR_MONTO_MENOR_IGUAL_A_CERO);
            Saldo += monto;
        }
        public void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new System.Exception (ERROR_MONTO_MENOR_IGUAL_A_CERO);
            Saldo -= monto;
        }
    }
}