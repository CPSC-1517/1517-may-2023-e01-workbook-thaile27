namespace OOPsReview
{
    public static class Utilities
    {
        // static classes are NOT instantiated by the outside user (developer/code)
        // static class items are referenced using: classname.xxxx
        // method within this class have the keyword 'static' in their signature
        // static classes are shared between all outside users at the same time
        // DO NOT consider saving data within a static class BECAUSE  you cannot be certain
        // it will be there when you use the class again.
        // Consider placing GENERIC re-usable methods with a static class


        // sample of a generic method: numeric is a zero or positive value

        public static bool IsZeroOrPositive(double value)
        {
            // a structured method (apply to loops, etc.) will have a single entry point
            // and a single exit point 
            // In this course, you will AVOID where possible multiple returns from a method
            // In this course, you will AVOID using a break to exit a loop structure or if structure

            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }

        // overload the IsZeroOrPositive so that it uses integers or decimals
        public static bool IsZeroOrPositive(int value)
        {
            // a structured method (apply to loops, etc.) will have a single entry point
            // and a single exit point 
            // In this course, you will AVOID where possible multiple returns from a method
            // In this course, you will AVOID using a break to exit a loop structure or if structure

            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }

        public static bool IsZeroOrPositive(decimal value)
        {
            // a structured method (apply to loops, etc.) will have a single entry point
            // and a single exit point 
            // In this course, you will AVOID where possible multiple returns from a method
            // In this course, you will AVOID using a break to exit a loop structure or if structure

            bool valid = true;
            if (value < 0)
            {
                valid = false;
            }
            return valid;
        }
    }
}
