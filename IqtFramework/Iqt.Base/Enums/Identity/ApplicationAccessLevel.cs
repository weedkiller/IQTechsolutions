namespace Iqt.Base.Enums.Identity
{
    /// <summary>
    /// The application level of access
    /// </summary>
    public enum ApplicationAccessLevel
    {
        /// <summary>
        /// The head office level
        /// </summary>
        Administrator,

        /// <summary>
        /// The Franchisee level
        /// </summary>
        Franchisor,

        /// <summary>
        /// The shop level
        /// </summary>
        Supervisor,

        /// <summary>
        /// The point of sale level
        /// </summary>
        Cashier,

        /// <summary>
        /// The point of sale level
        /// </summary>
        User,

        /// <summary>
        /// User has no Application access
        /// </summary>
        None
    }
}
