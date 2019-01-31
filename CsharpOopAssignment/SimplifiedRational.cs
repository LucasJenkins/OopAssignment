using System;

namespace CsharpOopAssignment
{
    public class SimplifiedRational : RationalBase
    {
        
        /**
         * Determines the greatest common denominator for the given values
         *
         * @param a the first value to consider
         * @param b the second value to consider
         * @return the greatest common denominator, or shared factor, of `a` and `b`
         * @throws InvalidOperationException if a <= 0 or b < 0
         */
        public static int Gcd(int a, int b)
        {
            if (a <= 0 || b < 0)
            {
                throw new InvalidOperationException($"{b} was less than 0");
            }
            if (b == 0)
            {
                return a;
            }    
                return Gcd(b, a % b);
        }

        /**
         * Simplifies the numerator and denominator of a rational value.
         * <p>
         * For example:
         * `simplify(10, 100) = [1, 10]`
         * or:
         * `simplify(0, 10) = [0, 1]`
         *
         * @param numerator   the numerator of the rational value to simplify
         * @param denominator the denominator of the rational value to simplify
         * @return a two element array representation of the simplified numerator and denominator
         * @throws InvalidOperationException if the given denominator is 0
         */
        public static int[] Simplify(int numerator, int denominator)
        {   
            int[] simplified = new int[2];
            if(denominator==0){
                throw new InvalidOperationException("Cannt Divide by 0");
            }
            if(numerator==0){
                simplified[0] = 0;
                simplified[1] = denominator;
                return simplified;
            }
            simplified[0] = numerator/Gcd(Math.Abs(numerator), Math.Abs(denominator));
            simplified[1] = denominator/Gcd(Math.Abs(numerator), Math.Abs(denominator));
            return simplified;
        }

        /**
         * Constructor for rational values of the type:
         * <p>
         * `numerator / denominator`
         * <p>
         * Simplification of numerator/denominator pair should occur in this method.
         * If the numerator is zero, no further simplification can be performed
         *
         * @param numerator   the numerator of the rational value
         * @param denominator the denominator of the rational value
         */
        public SimplifiedRational(int numerator, int denominator) : base(numerator, denominator)
        {
	        int[] array = new int[2];
            if(numerator==0){
                Numerator = 0;
                Denominator = denominator;
            }
            array = Simplify(numerator, denominator);
            Numerator = array[0];
            Denominator = array[1];
        }

        /**
		 * Specialized constructor to take advantage of shared code between
		 * Rational and SimplifiedRational
		 * <p>
		 * Essentially, this method allows us to implement most of RationalBase methods
		 * directly in the interface while preserving the underlying type
		 *
		 * @param numerator
		 *            the numerator of the rational value to construct
		 * @param denominator
		 *            the denominator of the rational value to construct
		 * @return the constructed rational value
		 * @throws ArgumentException
		 *             if the given denominator is 0
		 */
        public override RationalBase Construct(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException();
            }

            int[] array = new int[2];
            array = Simplify(numerator, denominator);
            SimplifiedRational returnObj = new SimplifiedRational(array[0], array[1]);
            return returnObj;
        }

        /**
         * @param obj the object to check this against for equality
         * @return true if the given obj is a SimplifiedRational value and its
         * numerator and denominator are equal to this rational value's numerator and denominator,
         * false otherwise
         */
        public override bool Equals(object obj)
        {
	        if(obj is SimplifiedRational){
                SimplifiedRational s = (SimplifiedRational)obj;
                if(s.Numerator==this.Numerator && s.Denominator==this.Denominator){
                    return true;
                }

            }
            return false;
        }

        /**
         * If this is positive, the string should be of the form `numerator/denominator`
         * <p>
         * If this is negative, the string should be of the form `-numerator/denominator`
         *
         * @return a string representation of this rational value
         */
        public override string ToString()
        {
	        /*if(Math.Sign(this.Numerator)==-1 && Math.Sign(this.Denominator)==-1){
                    return "-numerator/denominator";
            }*/
            return $"{this.Numerator}/{this.Denominator}";
        }
    }
}