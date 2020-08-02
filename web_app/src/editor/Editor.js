import ReactQuill from 'react-quill';
import debounce from '../helpers';
import BorderColorIcon from '@material-ui/icons/BorderColor';
import { withStyles } from '@material-ui/core/styles';
import styles from './styles'
import React, { Component } from 'react'
import Grid from '@material-ui/core/Grid';
import Input from '@material-ui/core/Input';



class Editor extends Component {
  constructor() {
    super();
    this.state = {
      text: '',
      title: '',
      id: '',
      tags: '',
      fired: false,
      tag: ''

    };
  }



  componentDidMount = () => {
    this.setState({
      text: this.props.selectedNote.body,
      title: this.props.selectedNote.title,
      id: this.props.selectedNoteIndex,
      tags: this.props.selectedNote.tags
    });
  }

  componentDidUpdate = () => {
    if (this.props.selectedNoteIndex !== this.state.id) {
      console.log('fired');
      this.setState({
        text: this.props.selectedNote.body,
        title: this.props.selectedNote.title,
        id: this.props.selectedNoteIndex,
        tags: this.props.selectedNote.tags,
      });
    }
  }

  render() {

    const { classes } = this.props;


    return (
      <div className={classes.editorContainer}>
        

        <Grid item xs={12} className={classes.titleInput}>
        <BorderColorIcon style = {{ marginTop : "5px" , paddingRight : "5px"}}></BorderColorIcon>
          <Input
            autoFocus="true"
            style={{ color: "white", width: "200px" }}
            placeholder='Note title...'
            value={this.state.title ? this.state.title : ''}
            onChange={(e) => this.updateTitle(e.target.value)}>

          </Input>

       
        </Grid>
        <ReactQuill
          value={this.state.text}
          onChange={this.updateBody}
          modules={Editor.modules}
          formats={Editor.formats}
        //  placeholder={this.props.placeholder}
        >
        </ReactQuill>
      </div>
    );
  }

  
  handleChange = async (value) => {
    await this.setState({ tags: value });
    this.update();
  }

  updateBody = async (val) => {
    await this.setState({ text: val });
    this.update();
  };
  updateTitle = async (txt) => {
    await this.setState({ title: txt });
    this.update();
  }
  update = debounce(() => {
    this.props.noteUpdate(this.state.id, {
      title: this.state.title,
      body: this.state.text,
      tags: this.state.tags
    })
  }, 1500);
}

export default withStyles(styles)(Editor);

var toolbarOptions = [
  ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
  ['blockquote', 'code-block'],

  [{ 'header': 1 }, { 'header': 2 }], 
                                        // custom button values
 [{ 'list': 'ordered'}, { 'list': 'bullet' }],
//[{ 'script': 'sub'}, { 'script': 'super' }],      // superscript/subscript
  [{ 'indent': '-1'}, { 'indent': '+1' }],          // outdent/indent
  [{ 'direction': 'rtl' }],                         // text direction

  [{ 'size': [] }],  // custom dropdown
  [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

  [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
  [{ 'font': [] }],
  [{ 'align': [] }],
  ['image', 'video' , 'link'],

  ['clean']                                         // remove formatting button
];

Editor.modules = {
  toolbar: toolbarOptions,

   clipboard: {
     // toggle to add extra line breaks when pasting HTML:
     matchVisual: true,
   }
}

Editor.formats = [
  'header', 'font', 'size', 'code-block',
  'bold', 'italic', 'underline', 'strike', 'blockquote',
  'list', 'bullet', 'indent', 'color', 'background',
  'image', 'video', 'clean'
]

