namespace hotel_application
{
    // This interface is implemented by the Launcher activity which enabled different forms to pass their data.
    public interface DataTransferDelegate
    {
        public void onCustomerDataAcquire(CustomerData customerData);

        public void UserMessage(bool agree);

        public void onFormClose(Form form);
    }
}
