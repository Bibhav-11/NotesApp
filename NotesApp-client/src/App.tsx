import { useEffect, useState } from "react";
import styled from "@emotion/styled";
import { Box, TextField } from "@mui/material";
import notesapi from "./api/notes";
import NoteCard from "./components/NoteCard";
import NoteModal from "./components/NoteModal";
import NoteCreate from "./components/NoteCreate";
import NoteMenu from "./components/NoteMenu";

interface note {
  id: number;
  title: string;
  description: string;
}

interface selectedNote {
  title?: string;
  description?: string;
}

const StyledTextField = styled(TextField)`
  .MuiOutlinedInput-input {
    cursor: pointer;

    &:focus {
      cursor: text;
    }
  },
  .MuiOutlinedInput-root:hover {
    cursor: pointer;
  }

  }
`;

function App() {
  const [notes, setNotes] = useState([]);
  const [selectedNote, setSelectedNote] = useState(null);
  const [open, setOpen] = useState(false);

  const [anchor, setAnchor] = useState(null);

  useEffect(() => {
    notesapi.get("/api/notes").then((res) => setNotes(res.data));
  }, []);

  const handleSubmit = async (id: number, notes: object) => {
    await notesapi.put(`/api/notes/${id}`, notes);
    updateNote(id);
  };

  const handleDelete = async (id: number) => {
    await notesapi.delete(`/api/notes/${id}`);
    setNotes((notes) => notes.filter((note) => note.id !== id));
  };

  const postNote = async (note) => {
    await notesapi.post("/api/notes", note);
    setNotes((notes) => [...notes, note]);
  };

  const getLastHistory: object = async (id: number) => {
    const response = await notesapi.get(`api/notes/${id}/histories/last`);
    return response;
  };

  const updateNote = async (id: number) => {
    const { data: response } = await notesapi.get(`/api/notes/${id}`);
    setNotes((prevNote) =>
      prevNote.map((note) => {
        if (note.id !== id) return note;
        else return response;
      })
    );
  };

  const renderedNotes = notes.map((note: note) => {
    return (
      <NoteCard
        setAnchor={setAnchor}
        onClick={() => {
          setOpen(true);
          setSelectedNote(note);
        }}
        key={note.id}
        note={note}
        setSelectedNote={setSelectedNote}
      />
    );
  });

  return (
    <Box sx={{ maxWidth: "1200px", margin: "0 auto", padding: "2rem 0" }}>
      <NoteCreate post={postNote} />
      <Box
        sx={{
          display: "grid",
          gridTemplateColumns: "repeat(auto-fill, minmax(240px, 1fr))",
          gridGap: "1rem",
          marginTop: "3rem",
        }}
      >
        {renderedNotes.reverse()}
        <NoteMenu
          handleDelete={handleDelete}
          anchor={anchor}
          setAnchor={setAnchor}
          id={selectedNote?.id || null}
        />
      </Box>
      <NoteModal
        handleSubmit={handleSubmit}
        selectedNote={selectedNote}
        setSelectedNote={setSelectedNote}
        open={open}
        setOpen={setOpen}
        history={getLastHistory}
      />
    </Box>
  );
}

export default App;
