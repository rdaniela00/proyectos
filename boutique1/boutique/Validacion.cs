using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boutique
{
    class Validacion
    {
        public void sololetras(KeyPressEventArgs evento)
        {

            try
            {

                if (char.IsLetter(evento.KeyChar))
                {
                    evento.Handled = false;
                }
                else if (char.IsControl(evento.KeyChar))
                {
                    evento.Handled = false;
                }
                else if (char.IsSeparator(evento.KeyChar))
                {
                    evento.Handled = false;
                }
                else
                {
                    evento.Handled = true;
                }


            }
            catch (Exception)
            {
                
                throw;
            }
        
        }


        public void solonumeros(KeyPressEventArgs evento)
        {

            try
            {

                if (char.IsNumber(evento.KeyChar))
                {
                    evento.Handled = false;
                }
                else if (char.IsControl(evento.KeyChar))
                {
                    evento.Handled = false;
                }
                else if (char.IsSeparator(evento.KeyChar))
                {
                    evento.Handled = false;
                }
                else
                {
                    evento.Handled = true;
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
