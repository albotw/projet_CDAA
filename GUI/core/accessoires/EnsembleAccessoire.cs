﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using projet_CDAA_2020_2021.datastructures;

namespace projet_CDAA_2020_2021.core.accessoires
{
    public class EnsembleAccessoire : Ensemble<Accessoire>
    {
        public EnsembleAccessoire() : base()
        { }

        public EnsembleAccessoire(List<Accessoire> l) : base(l)
        { }

        public override void Init()
        {
            Add(new Accessoire("Mannette de ps4","Sony", "Playstation", Type.Mannette, GUI.Properties.Resources.MANETTE));
            Add(new Accessoire("écran 144Hz","ACER", "PC", Type.TV, GUI.Properties.Resources.ECRAN));
            Add(new Accessoire("Casqe GAMERZ","Logitech", "PC", Type.Casque, GUI.Properties.Resources.CASQUE));
            Add(new Accessoire("Camera","Logitech", "PC", Type.Camera, GUI.Properties.Resources.CAMERA));
        }

        public override List<Accessoire> Search(string property, object arg)
        {
            List<Accessoire> output = new List<Accessoire>();

            foreach (Accessoire a in liste)
            {
                switch (property)
                {
                    case "nom":
                        if (a.Nom == (string)arg)
                            output.Add(a);
                        break;
                    case "fabriquant":
                        if (a.FabriquantPays == (string)arg)
                            output.Add(a);
                        break;

                    case "plateforme":
                        if (a.Plateforme == (string)arg)
                            output.Add(a);
                        break;
                  
                    case "type":
                        if (a.Type == (Type)arg)
                            output.Add(a);
                        break;
                }
            }

            return output;
        }

        public override List<string[]> ToStringArray()
        {
            List<string[]> output = new List<string[]>();
            foreach (Accessoire a in liste)
            {
                output.Add(a.ToStringArray().ToArray());
            }

            return output;
        }
    }
}
