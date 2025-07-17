# How to prevent native keyboard when editing cells in .NET MAUI DataGrid?

This article demonstrates how to prevent native keyboard when editing cells in [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

In SfDataGrid, custom rendering can be used to prevent the Android native keyboard from appearing while preserving edit functionality. This is achieved by overriding the OnInitializeEditView method, where the platform-specific Android native control is accessed and its ShowSoftInputOnFocus property is set to false. This approach maintains the focus behavior for editing while explicitly instructing Android not to display the soft keyboard when the control receives focus.

## C#

```C#
public MainPage()
{
    InitializeComponent();
    dataGrid.CellRenderers.Remove("Text");
    dataGrid.CellRenderers.Add("Text", new CustomTextCellRenderer());
}

public class CustomTextCellRenderer : DataGridTextBoxCellRenderer
{
    public override void OnInitializeEditView(DataColumnBase dataColumn, SfDataGridEntry view)
    {
        base.OnInitializeEditView(dataColumn, view);
#if ANDROID
        if (view != null && view is SfDataGridEntry entry && DataGrid != null)
        {
            DataGrid.Dispatcher.DispatchDelayed(TimeSpan.FromMilliseconds(100), () =>
            {
                var nativeEntry = entry.Handler?.PlatformView as Android.Widget.EditText;
                if (nativeEntry != null)
                {
                    nativeEntry.ShowSoftInputOnFocus = false;
                }
            });
        }
#endif
    }
}
```

## Xaml

```xml
<syncfusion:SfDataGrid
        x:Name="dataGrid"
        AllowEditing="True"
        SelectionUnit="Cell"
        SelectionMode="Single"
        ItemsSource="{Binding OrderInfoCollection}">

    <syncfusion:SfDataGrid.Columns>
        <syncfusion:DataGridNumericColumn HeaderText="Order ID" Format="0"
            MappingName="OrderID" Width="150"/>
        <syncfusion:DataGridTextColumn HeaderText="Customer ID"
            MappingName="CustomerID"
            Width="150" />
        <syncfusion:DataGridTextColumn HeaderText="Ship Country"
            MappingName="ShipCountry"
            Width="150" />
    </syncfusion:SfDataGrid.Columns>

</syncfusion:SfDataGrid>
```

You can download this example on [GitHub](https://github.com/SyncfusionExamples/How-to-prevent-native-keyboard-when-editing-cells-in-.NET-MAUI-DataGrid).