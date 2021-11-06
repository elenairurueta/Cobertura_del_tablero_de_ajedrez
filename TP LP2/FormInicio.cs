using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_LP2
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Global.MainForm_ = new MainForm();
            Global.MainForm_.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnalisis_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nosotras decidimos utilizar el algoritmo de backtracking. Creamos una lista con las 8 piezas a colocar, y arbitrariamente decidimos en qué orden se colocan y en qué rango de posiciones. Para colocarla, analizamos las mejores posiciones en las que se puede colocar las piezas, ordenadas según el criterio de cuántos casilleros (no amenazados) amenazaría si se colocara en esa posición. En el caso del rey y los caballos, como son los que más libertad tienen para moverse en tablero, las mejores posiciones donde deberían colocarse se definen dependiendo de aquellas que quedaron sin atacar al momento de colocarlos.\nNuestra función recursiva es colocarPieza() de la clase Pieza: al colocar la primera de la lista en su mejor posición, se vuelve a llamar a colocarPieza() pero para la siguiente pieza de la lista (también en su mejor posición) y así sucesivamente hasta que se coloca la última o se encuentra una solución(depth-first). Si se coloca la última y todavía no hemos encontrado una solución, esta prueba en todas sus mejores posiciones posibles y, si todavía no hay solución(o si lo hay y queremos seguir buscando) vuelve para atrás, colocando la anteúltima pieza de la lista en su segunda mejor posición, la última en su mejor posicion (ahora cambiada porque se vuelve a buscar), y así sucesivamente.\nEn este caso en específico, comenzamos colocando la reina (que tiene 4 mejores posiciones) para luego colocar las torres, los alfiles, el rey y los caballos, cada una con sus respectivas mejores posiciones.Es por esto que nuestra búsqueda se terminaría, si no ha de encontrar todos los tableros solicitados, cuando la reina haya colocado sus 4 mejores posiciones y sus árboles respectivos.\nEn colocarPieza() llamamos al getMejoresPos() de la pieza que estamos considerando. Este método tiene un tiempo de ejecución constante ya que la cantidad de mejores posiciones no depende del tamaño de la entrada, sino que ya están preestablecidas y/o podadas (como es el caso del rey y los caballos) y, por lo tanto, el tiempo que se tarda en ordenarlas también es de orden constante. Luego, para cada mejor posición, se asigna el caracter de esa pieza a la primer mejor posición en el tablero de piezas, se actualizan las amenazas y se llama a esSolucion().\nEn esSolucion(), verificamos que este tablero lo sea con un doble for de orden constante y se llama a agregarSolucion(). Allí, se compara con la lista de tableros preexistentes, cuya cantidad de elementos varía de forma: 1, 2, 3... n; y, si no lo encuentra, lo agrega a la lista.\nLuego, con ese tablero solución seguimos nuestro procedimiento de backtracking: si todavía le quedan mejores posiciones por probar a la última pieza, sigue con el for, sino vuelve para atrás en el árbol de recursión.\nComo la lista de mejores pos de cada pieza va a tener la misma cantidad de elementos para cada ejecución del programa, podemos definir que el costo al generar un tablero en el peor caso es aquel en el cual todas las soluciones se encuentren luego de recorrer toda (o casi toda) la lista de mejores posiciones de cada pieza. En este caso, llamaríamos 128000 veces a colocarPieza() para encontrar únicamente el primer tablero.\nEn el mejor caso de un sólo tablero encontraríamos la solución en el primer recorrido, es decir, en la primer posición de la lista de mejores posiciones de cada pieza. Llamaríamos a colocarPieza() 8 veces.\nSi ahora tenemos n tableros, el mejor caso sería encontrar la primer solución en el primer recorrido y las otras n soluciones al cambiar de lugar la última pieza (es decir, sin que haga falta subir en el árbol de recursión). En este caso, llamaríamos a colocarPieza()  8 + n - 1 = n + 7 veces.\nAsí la cota inferior es Omega(n): lineal.\n El método de poda que utilizamos se basa en limitar la cantidad de mejores posiciones a probar, siempre quedándonos con las que más casilleros amenazan, a un número determinado por las variables globales PODAREY, PODATORRE, PODAALFIL, PODACABALLO, etc.");
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
