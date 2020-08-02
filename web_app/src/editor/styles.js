const styles = theme => ({
    root: {
      backgroundColor: theme.palette.background.paper,
      height: 'calc(100% - 35px)',
      position: 'absolute',
      left: '0',
      width: '300px',
      boxShadow: '0px 0px 5px black'
    },
    titleInput: {
      display : "flex",
      color : "white",
      marginLeft : "300px",
      boxSizing: 'border-box',
      border: 'none',
      padding: '5px',
      fontSize: '20px',
      width: 'calc(100% - 300px)',
      backgroundColor: '#29487d',
      paddingLeft: '20px',
    },
    editIcon: {
      position: 'relative',

      color: 'white',
      width: '5',
      height: '5'
    },
    editorContainer: {
      height: '700px',
      boxSizing: 'border-box',

    }
  });
  
  export default styles;