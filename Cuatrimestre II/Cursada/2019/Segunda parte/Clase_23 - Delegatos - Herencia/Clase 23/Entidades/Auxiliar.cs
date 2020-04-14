using Entidades;

public delegate void DelegadoSueldo(Empleado empleado, float sueldo);

public delegate void DelSueldo(EmpleadoMejorado empleado, EmpleadoSueldoArs sueldo);

public enum TipoManejador
{
    limiteSueldo,
    log,
    ambos
}