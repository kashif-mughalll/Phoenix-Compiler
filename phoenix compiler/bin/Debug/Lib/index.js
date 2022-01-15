var targetObj = {};
var lines;
let Terminal = false;
let data = '';
let tokenSet = {};
var parent = targetObj;
var parentList = [];
var parentCount = 0;
let first = true;
let AllowTokenSet = true;
let AllowTokenSetView = false;


var tree_structure = {
  chart: {

    //%%%%%%%%%%%%% CONFIGURATIONS %%%%%%%%%%%%%%%

    container: '#chart-cont',
    levelSeparation: 80,
    siblingSeparation: 170,
    subTeeSeparation: 140,
    nodeAlign: 'BOTTOM',
    scrollbar: 'fancy',
    padding: 75,
    node: { HTMLclass: 'evolution-tree' },
    connectors: {
      type: 'step',
      style: {
        'stroke-width': 2,
        'stroke-linecap': 'round',
        stroke: '#ddd',
      },
    },
  },
  nodeStructure: {}
};


try {
  GenerateTreeStructure();
} catch (e) {
  console.error("things mal functioning");
  console.error(e)
}

tree_structure.nodeStructure = { ...targetObj };
var T = new Treant(tree_structure);

// Tree formation Algo $$$$$$$$$$$$$$$$$$$$$

function GenerateTreeStructure() {
  if (!Data) return;
  lines = Data.trim().split('\n');

  for (let i = 0; i < lines.length; i++) {
    let tokens = lines[i].split(':');
    if (tokens.length > 2) {
      if (tokens[0].trim() == 'Terminal') Terminal = true;
      else Terminal = false;
      if (tokens[1]) data = tokens[1].trim();
      else console.error('error found at i: ' + i);

      if (tokens[2]) {
        let token = tokens[2].trim().split('%');
        tokenSet.tokenSet1 = reduceData(token[0].trim(), 24);
        tokenSet.tokenSet2 = reduceData(token[1].trim(), 24);
        tokenSet.tokenSet3 = reduceData(token[2].trim(), 24);
      }
      else console.error('error no token set found at i: ' + i);

      if (!Terminal) {
        if (first) {
          (parent.text = { name: data }), (parent.HTMLclass = 'the-parent');
          parent.children = [];
          parentCount++;
          parent = parent.children;
          parentList.push(data);
          first = false;
        } else {
          let obj = {
            text: !AllowTokenSet ? { name: data } : { name: data, ...tokenSet },
            HTMLclass: 'the-parent',
            children: [],
          };
          parent.push(obj);
          parentCount++;
          parent = obj.children;
          parentList.push(data);
        }
      } else {
        // Terminal Work Here
        let obj = {
          text: data == "False" ? { False: data } : { terminal: reduceData(data) },
        };
        if (AllowTokenSet) {
          obj = {
            text: data == "False" ? { False: data, ...tokenSet } : { terminal: reduceData(data), ...tokenSet },
          };
        }
        parent.push(obj);
        if (data == 'False') {
          parentCount--;
          parentList.pop()
          setParent();
        }
      }
    }
    else {
      // back track
      if(tokens[0].trim() != 'Back-Track') alert("problem");
      parentCount--;
      parentList.pop()
      setParent();
    }
  }
}


function setParent() {
  let temp = targetObj;
  temp = temp.children;
  for (let i = 0; i < parentCount - 1; i++) {
    temp = temp[getIndexByName(parentList[i + 1], temp)].children;
  }
  parent = temp;
}

function getIndexByName(name, arr) {
  for (let i = 0; i < arr.length; i++) {
    if (arr[i].text.name == name) return i;
  }
  console.error("index not found")
  return -1;
}

function reduceData(data, chars = 35) {
  if (typeof (data) == "string" || true)
    if (data.length > chars) {
      let str = data.substring(0, chars);
      str += ' ...';
      if (data[0] == '"') str += '"';
      return str;
    }
  return data;
}


// Dragging work

const ele = document.querySelector('.chart');
let moving = false;
let mousePos = { x: 0, y: 0 };
let Scrollpos = { x: 0, y: 0 };
let LastScrollVal = { x: 0, y: 0 };

ele.addEventListener('mousedown', (e) => {
  moving = true;
});

ele.addEventListener('mouseup', (e) => {
  moving = false;
});

ele.addEventListener('mousemove', (e) => {
  if (moving) {
    let defX = -(e.clientX - mousePos.x);
    let defY = -(e.clientY - mousePos.y);
    LastScrollVal.x = defX + Scrollpos.x;
    LastScrollVal.y = defY + Scrollpos.y;
    ele.scroll(defX + Scrollpos.x, defY + Scrollpos.y)
  } else {
    mousePos.x = e.clientX;
    mousePos.y = e.clientY;
    Scrollpos.x = LastScrollVal.x;
    Scrollpos.y = LastScrollVal.y;
  }
});


document.getElementById('toggleTokenSetBtn').addEventListener('click', (e) => {
  e.preventDefault();  
  let select1 = Array.from(document.querySelectorAll('.node-tokenSet1'));
  let select2 = Array.from(document.querySelectorAll('.node-tokenSet2'));
  let select3 = Array.from(document.querySelectorAll('.node-tokenSet3'));
  
  select1.forEach(e => {
    if (AllowTokenSetView) e.style.display = 'none';
    else e.style.display = 'block'
  });  

  select2.forEach(e => {
    if (AllowTokenSetView) e.style.display = 'none';
    else e.style.display = 'block'
  });  

  select3.forEach(e => {
    if (AllowTokenSetView) e.style.display = 'none';
    else e.style.display = 'block'
  });  

  if (AllowTokenSetView) {
    AllowTokenSetView = false;

  } else {
    AllowTokenSetView = true;
  }
})

