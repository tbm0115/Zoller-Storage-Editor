The Zoller:Storage Editor provides another means of creating/editing Storage objects for Zoller TMS software. You have control of adding Shelves/Drawers and Cells to existing objects, reformatting layout of objects, renaming, and changes to other physical Storage properties.

#How it works#
To get started you will need to export at least one Storage object from Zoller to XML (Menu -> Import/Export -> Storage -> Export settings. Select 1+ items. Press F1 and select output filepath).

Next, open Zoller:Storage Editor and open the exported XML file. Once opened, there should be a list of Storage objects in the TreeView to the left. Cycling through each node/subnode in the treeview will update the graphics pane to the right and details pane to the bottom-right.

#Graphics Pane#
The graphics pane provides a basic orthographic view of the storage object, showing Front View, Side View, Top View, and a Cell view (when a cell system is available). Objects will be highlighted as you select them in the TreeView.

Zoller:Storage Editor also allows you to save copies of the image in the graphics pane. You can either save by going to Tool -> Save Image... and specifying the filepath or you can simply drag the graphics pane into Windows Explorer or your Desktop. This might prove useful for conducting audits to provide a visual representation.

#Details Pane#
The details pane allows you to adjust some of the properties of the storage object such as:

 - Description
 - Width
 - Depth
 - Height
 - X-Location
 - Y-Location
 - Z-Location

#Saving#
Any changes made in Zoller: Storage Editor will not be applied directly to Zoller TMS. In order to save information back to Zoller, you will need to save your changes back to the XML file (Ctrl+S or File -> Save), then Import the XML back into Zoller.

However, you may encounter the issue where the changes are not actually being applied to Zoller after importing. This is most likely because the object already exists in Zoller TMS. To work around this, you will need to remove the object from Zoller, then import the XML. Note that Zoller will not let you remove the object if other objects (Tools, Accessories, etc.) are stored in the storage location. If this is the case, you will need to either remove your inventory or transfer the items to another storage location temporarily.

#Shortcuts#
Nearly every action has a keyboard shortcut associated with it to ensure the most efficiency as you create/edit your storage objects.

Additionaly, four hotkeys are available that you can customize with keystroke combinations. With hotkeys, you can even string together series of the applications keyboard shortcuts such as **Normalize Horizontally**, **Fill Width**, and **Fill Depth** with a single press of a button. Function keys **F9**, **F10**, **F11**, and **F12** are reserved as hotkeys and have virtually no limit to how many keystroke combinations you wish to use.