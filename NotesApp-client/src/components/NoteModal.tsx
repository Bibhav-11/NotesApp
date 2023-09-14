import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  TextField,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";

import formatCreatedTime from "../helpers/formatDate";

// interface noteModal {
//     open: boolean,
//     selectedNote: {
//         title: string,
//         description: string,
//     },
// }

function NoteModal({
  open,
  selectedNote,
  setSelectedNote,
  setOpen,
  handleSubmit,
  history,
}) {
  const [noteTitle, setNoteTitle] = useState("");
  const [noteDescription, setNoteDescription] = useState("");
  const [updatedTime, setUpdatedTime] = useState(null);

  useEffect(() => {
    if (!selectedNote) return;
    setNoteTitle(selectedNote.title);
    setNoteDescription(selectedNote.description);
    (async () => {
      const response = await history(selectedNote.id);
      setUpdatedTime(response.data.activityTime);
    })();
  }, [selectedNote]);

  const onNotesChangeSubmit = () => {
    setOpen(false);
    setUpdatedTime(null);
    setSelectedNote(null);
    if (
      selectedNote.title === noteTitle &&
      selectedNote.description == noteDescription
    ) {
      return;
    }
    handleSubmit(selectedNote.id, {
      id: selectedNote.id,
      title: noteTitle,
      description: noteDescription,
    });
  };

  if (!selectedNote) return;
  return (
    <Dialog
      fullWidth={true}
      maxWidth="sm"
      open={open}
      onClose={onNotesChangeSubmit}
    >
      <DialogContent sx={{ padding: "10px 5px" }}>
        <TextField
          sx={{ "& fieldset": { border: "none" } }}
          fullWidth
          value={noteTitle}
          onChange={(e) => setNoteTitle(e.target.value)}
          placeholder="Title"
        />
        <TextField
          sx={{ "& fieldset": { border: "none" } }}
          fullWidth
          value={noteDescription}
          onChange={(e) => setNoteDescription(e.target.value)}
          placeholder="Note"
          multiline
        />
      </DialogContent>
      <DialogActions>
        <Typography
          sx={{
            marginRight: "auto",
            paddingLeft: "12px",
            fontSize: "12px",
            opacity: "0.5",
          }}
        >
          {updatedTime && `Updated ${formatCreatedTime(updatedTime)}`}
        </Typography>
        <Button onClick={onNotesChangeSubmit}>Close</Button>
      </DialogActions>
    </Dialog>
  );
}

export default NoteModal;
