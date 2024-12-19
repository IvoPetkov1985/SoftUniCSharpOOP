using System.Text;

namespace ClassBoxData.Models
{
    public class Box
    {
        private const string InputNumberErrorMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(InputNumberErrorMessage, nameof(Length)));
                }

                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(InputNumberErrorMessage, nameof(Width)));
                }

                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(InputNumberErrorMessage, nameof(Height)));
                }

                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * Length * Width + LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double Volume()
        {
            return Length * Width * Height;
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            builder.AppendLine($"Surface Area - {SurfaceArea():F2}");
            builder.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
            builder.AppendLine($"Volume - {Volume():F2}");

            return builder.ToString().TrimEnd();
        }
    }
}
