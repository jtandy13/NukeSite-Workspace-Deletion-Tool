# NukeSite-Workspace-Deletion-Tool
Workspace deletion tool for iManage Work

The idea behind this tool was to provide system administrators for the iManage document management system a tool to quickly delete large amounts of workspaces. 

## Configuration
In order to use the tool, you first need to give it a list of the iManage Work server(s) and database(s) that you want to use.
To do that, open the MainWindow.xaml file in any text editor. Find the ComboBox element called "DBBox". Replace the generic database names with the ones you will need. Do the same for the ComboBox called "ServerBox". Remove the generic server names and add the name of any iManage Work server that you want to use.

Change, remove, or add more database names as needed:
```xml
<ComboBox x:Name="DBBox" HorizontalAlignment="Left" Height="24" Margin="42,140,0,0" 
     VerticalAlignment="Top" Width="135" Text ="{Binding DBname, Mode=TwoWay}">
     <ComboBoxItem Name="DB1">Database1</ComboBoxItem>
     <ComboBoxItem Name="DB2">Database2</ComboBoxItem>
     <ComboBoxItem Name="DB3">Database3</ComboBoxItem>
     <ComboBoxItem Name="DB4">Database4</ComboBoxItem>
</ComboBox>
```

Add in the iManage Work servers that you need:
```xml
<ComboBox x:Name="ServerBox" HorizontalAlignment="Left" Height="24" Margin="42,82,0,0" 
     VerticalAlignment="Top" Width="135" Text ="{Binding serverName, Mode=TwoWay}">
     <ComboBoxItem Name="SERVER1">iManServer1</ComboBoxItem>
     <ComboBoxItem Name="SERVER2">iManServer2</ComboBoxItem>
</ComboBox>
```
## Running the tool
In order to run the tool you need to have a list of all the folder ids of all the workspaces that you need to delete. If flat-space filing is disabled on the database through the iManage server, you will need to make sure that all workspaces have been cleared of documents. Once you have the folder ids from SQL, save them as a csv file (do not include a column header). 
Open the tool. Choose the server, database, and specify the path of the csv file.

The tool uses trusted authentication so make sure that you run it with a Windows account that has access to delete workspaces in iManage.
