using System;

public class Boligrafo
{
    const short cantidadTintaMaxima = 100;
    private ConsoleColor color;
    private short tinta;
    //Constructor con parametros.
    public Boligrafo(short tinta, ConsoleColor color)
	{
        SetTinta(tinta);
        this.color = color;
	}
    //Listo
    public ConsoleColor GetColor()
    {
        return this.color;
    } 
    //Listo
    public short GetTinta()
    {
        return this.tinta;
    }
    //Listo [¿Para que uso el OUT?]
    public bool Pintar(int gasto, out string dibujo)
    {
        bool resultado = false;
        dibujo = "";
        if (this.tinta >= gasto)
        {
            Console.ForegroundColor = this.GetColor();
            for (int i=0; i < gasto; i++)
            {
                dibujo += "*";
            }
            Console.WriteLine(dibujo);
            this.SetTinta((short)((-1) * gasto));
            resultado = true;
            Console.ForegroundColor = ConsoleColor.White;
        }
        return resultado;
    }
    //Listo
    private void SetTinta(short tinta)
    {
        if (tinta >= 0 && tinta <= 100)
        
            this.tinta = tinta;
        
        else if (tinta < 0)
        
            this.tinta -= tinta; // Resto tinta
        
    }
    //Listo
    public void Recargar()
    {
        SetTinta(cantidadTintaMaxima);
    }
}
