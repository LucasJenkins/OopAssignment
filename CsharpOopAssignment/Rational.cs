using System;

namespace CsharpOopAssignment
{
    public class Rational : RationalBase
    {
        
        public Rational(int numerator, int denominator) : base(numerator, denominator) { 
            

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
         *             DONOT CHANGE OBJECT!!!!!RETURN COPY.
		 */
        public override RationalBase Construct(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException();
            }

            Rational returnObj = new Rational(numerator, denominator);
            return returnObj;

        }

        /**
         * @param obj the object to check this against for equality
         * @return true if the given obj is a rational value and its
         * numerator and denominator are equal to this rational value's numerator and denominator,
         * false otherwise
         */
        public override bool Equals(object obj)
        {
	        if(obj is Rational){
                Rational r=(Rational)obj;
                if(this.Denominator == r.Denominator&& this.Numerator== r.Numerator){
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