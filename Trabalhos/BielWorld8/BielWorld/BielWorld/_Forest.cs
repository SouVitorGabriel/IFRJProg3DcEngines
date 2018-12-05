using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace BielWorld
{
    class _Forest
    {
        private _Billboard[] billboards;

        public _Forest(Game game)
        {
            billboards = new _Billboard[10];

            for (int i = 0; i <= 9; i++)
            {
                billboards[i] = new _Billboard(game.GraphicsDevice, game, @"Textures\arvre2", @"Textures\arvre",
                                           Vector3.Zero, new Vector2(15, 25), _WallOrientation.South);
            }
        }

        public void Update(GameTime gameTime, _Camera camera)
        {
            foreach (_Billboard b in billboards)
            {
                b.Update(camera);
            }

            this.billboards[0].setCenter(new Vector3(55,  12, 3));
            this.billboards[1].setCenter(new Vector3(-55, 12, 0));
                                                          
            this.billboards[2].setCenter(new Vector3(25,  12, -10));
            this.billboards[4].setCenter(new Vector3(25,  12, 10));
                                                          
            this.billboards[8].setCenter(new Vector3(-3,   12, -55));
            this.billboards[9].setCenter(new Vector3(5,   12, 25));
                                                          
            this.billboards[3].setCenter(new Vector3(-25, 12, -25));
            this.billboards[5].setCenter(new Vector3(-25, 12, -10));
            this.billboards[6].setCenter(new Vector3(-25, 12, 10));
            this.billboards[7].setCenter(new Vector3(-25, 12, 25));
        }

        public void Draw(_Camera camera)
        {
            SelectionSort(billboards);

            for(int i = 0; i < billboards.Length; i++)
                billboards[i].Draw(camera);
        }

        public void SelectionSort(_Billboard[] vetor)
        {
            for (int indice = 0; indice < vetor.Length; ++indice)
            {
                int indiceMenor = indice;
                for (int indiceSeguinte = indice + 1; indiceSeguinte < vetor.Length; ++indiceSeguinte)
                {
                    if (vetor[indiceSeguinte].getDistance() > vetor[indiceMenor].getDistance())
                    {
                        indiceMenor = indiceSeguinte;
                    }
                }
                _Billboard aux = vetor[indice];
                vetor[indice] = vetor[indiceMenor];
                vetor[indiceMenor] = aux;
            }
        }
    }
}
