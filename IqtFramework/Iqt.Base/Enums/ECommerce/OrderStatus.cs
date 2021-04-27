namespace Iqt.Base.Enums.ECommerce
{
    /// <summary>
    /// The status of a order placed
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Waiting for payment to be done
        /// </summary>
        PaymentPending,

        /// <summary>
        /// Order is being processed
        /// </summary>
        Processing,

        /// <summary>
        /// Order is ready to be collected
        /// </summary>
        ReadyForCollection,

        /// <summary>
        /// Order has been shipped
        /// </summary>
        Shipped,

        /// <summary>
        /// Order has been delivered
        /// </summary>
        Delivered,

        /// <summary>
        /// The order has been completed
        /// </summary>
        Completed,

        /// <summary>
        /// The order has been cancelled
        /// </summary>
        Cancel
    }
}
