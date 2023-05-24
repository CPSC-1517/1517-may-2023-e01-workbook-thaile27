namespace OOPsReview
{
    public record Residence(int Number, string Street, string City, string Province, string PostalCode)
    {
        public override string ToString()
        {
            return $"{Number},{Street},{City},{Province},{PostalCode}";
        }
    }
}
