using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Noise
{
    public class Bands
    {

        public List<Stripe> stripes;

        public Bands()
        {
            stripes = new List<Stripe>();
        }

        public void AddStripe(byte _lower, byte _upper, Color _color)
        {
            stripes.Add(new Stripe(_lower, _upper, _color));
        }

        public void AddStripe(Stripe _stripe)
        {
            stripes.Add(_stripe);
        }

        public Color FindColor(byte _sample)
        {
            foreach(Stripe stripe in stripes)
            {
                if(stripe.contains(_sample))
                {
                    return stripe.color;
                }
            }

            return Color.HotPink;
        }
    }

    public class Stripe
    {
        public byte lower { get; set; }
        public byte upper { get; set; }
        public Color color { get; set; }

        public Stripe(byte _lower, byte _upper, Color _color)
        {
            lower = _lower;
            upper = _upper;
            color = _color;
        }

        public Stripe(byte _lower, byte _upper) : this(_lower, _upper, Color.Black) { }

        public bool contains(byte _sample)
        {
            return _sample >= lower && _sample <= upper;
        }
    }
}
