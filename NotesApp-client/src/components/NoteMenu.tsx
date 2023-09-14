import { Menu, MenuItem } from "@mui/material";

function NoteMenu({ anchor, setAnchor, id, handleDelete }) {
  const handleClose = () => setAnchor(null);
  if (!anchor) return;
  return (
    <Menu
      anchorEl={anchor}
      id="basic-menu"
      open={true}
      onClose={handleClose}
      MenuListProps={{
        "aria-labelledby": "basic-button",
      }}
    >
      <MenuItem
        onClick={() => {
          handleClose();
          handleDelete(id);
        }}
      >
        Delete
      </MenuItem>
    </Menu>
  );
}

export default NoteMenu;
