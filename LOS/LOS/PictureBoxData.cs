using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOS
{
    internal class PictureBoxData
    {
        public PictureBox numberPictureBox;
        public PictureBox chestPictureBox;

        public PictureBoxData(PictureBox numberPictureBox, PictureBox chestPictureBox)
        {
            this.numberPictureBox = numberPictureBox;
            this.chestPictureBox = chestPictureBox;
        }
    }
}
