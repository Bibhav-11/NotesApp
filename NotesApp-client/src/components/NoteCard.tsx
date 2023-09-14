import { Button, Menu, MenuItem, Paper, Typography } from "@mui/material";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import { useRef, useState } from "react";

interface noteCard {
  title: string;
  description: string;
}

function NoteCard({ note, onClick, setAnchor, setSelectedNote }) {
  const handleClick = (e) => {
    e.stopPropagation();
    setAnchor(e.currentTarget);
    setSelectedNote(note);
  };
  const noteRef = useRef();
  if (!note.title && !note.description)
    return (
      <Paper
        onClick={onClick}
        elevation={1}
        sx={{
          padding: "20px",
          cursor: "pointer",
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
          color: "rgba(0,0,0,0.5)",
          position: "relative",
        }}
      >
        <Typography>Empty Note</Typography>
        <MoreVertIcon
          sx={{
            position: "absolute",
            bottom: "5%",
            right: "5%",
            alignSelf: "flex-end",
            marginTop: "auto",
            padding: "5px",
            transition: "all .2s ease-in-out",
            borderRadius: "50%",
            "&:hover": {
              background: "#D3D3D3",
            },
          }}
          onClick={handleClick}
        />
      </Paper>
    );
  return (
    <Paper
      onClick={onClick}
      elevation={2}
      sx={{
        padding: "20px",
        cursor: "pointer",
        display: "flex",
        flexDirection: "column",
        gap: "1rem",
      }}
    >
      <Typography variant="h5">{note.title}</Typography>
      <Typography>{note.description}</Typography>
      {/* <Button
        sx={{ alignSelf: "flex-end", marginTop: "auto" }}
        onClick={handleClick}
      >
        Menu
      </Button> */}
      <MoreVertIcon
        sx={{
          alignSelf: "flex-end",
          marginTop: "auto",
          padding: "5px",
          transition: "all .2s ease-in-out",
          borderRadius: "50%",
          "&:hover": {
            background: "#D3D3D3",
          },
        }}
        onClick={handleClick}
      />
    </Paper>
  );
}

export default NoteCard;
