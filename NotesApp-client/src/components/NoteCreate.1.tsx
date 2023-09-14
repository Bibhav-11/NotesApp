import { Box, Button, Paper, TextField } from "@mui/material";
import { useState } from "react";

export function NoteCreate({ postNote }) {
  const [isFocused, setIsFocused] = useState(false);
  const [title, setTitle] = useState("");
  const [note, setNote] = useState("");

  const handleSubmit = async () => {
    setIsFocused(false);
    if (!(title && note)) return;
    const noteObject = { title: title, description: note };
    console.log(noteObject);
    notesapi.post("/api/notes", noteObject);
  };

  return (
    <Paper
      tabIndex={0}
      elevation={3}
      onFocus={() => setIsFocused(true)}
      onBlur={() => console.log("blur")}
      sx={{
        padding: "10px",
        margin: "0 auto",
        marginBottom: "1rem",
        cursor: "pointer",
        maxWidth: "600px",
      }}
    >
      {isFocused ? (
        <TextField
          sx={{ "& fieldset": { border: "none" } }}
          fullWidth
          placeholder="Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
        />
      ) : (
        ""
      )}
      <TextField
        sx={{ "& fieldset": { border: "none" } }}
        fullWidth
        placeholder="Note"
        value={note}
        onChange={(e) => setNote(e.target.value)}
      />

      {isFocused && (
        <Box
          onClick={handleSubmit}
          sx={{ display: "flex", justifyContent: "flex-end" }}
        >
          <Button>Close</Button>
        </Box>
      )}
    </Paper>
  );
}
