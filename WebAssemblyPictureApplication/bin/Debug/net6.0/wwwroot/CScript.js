async function makeChoco(layoutPath, picturePath, nameP, authorP, textP, nameK, authorK, textK, textColor) {
    var nameSize = nameK + "px";
    var authorSize = authorK + "px";
    var textSize = textK + "px";
    var nameY = 1630;

    var c = document.getElementById('canvas_id');
    document.body.appendChild(c);
    c.width = 3508;
    c.height = 2480;
    var ctx = c.getContext("2d");
    ctx.textAlign = 'center';


    var imageObj1 = new Image();
    var imageObj2 = new Image();
    imageObj1.src = layoutPath;
    imageObj1.onload = function () {
        ctx.drawImage(imageObj1, 0, 0, 3508, 2480);
        imageObj2.src = picturePath;
        imageObj2.onload = function () {
            var width = this.width;
            var hight = this.height;

            var koef = width / 927;
            var h = hight / koef;

            //ctx.drawImage(imageObj2, 1300, 430, 927, 1100);
            ctx.drawImage(imageObj2, 1300, 430, 927, h);
            ctx.fillStyle = textColor;
            ctx.font = nameSize + " Didona";
            var Y = h + 530;
            for (let k = 0; k < nameP.length; k++) {
                ctx.fillText(nameP[k], 1764, Y, 827);
                Y = Y + nameK;
            }
            ctx.font = authorSize + " Didona";
            for (let j = 0; j < authorP.length; j++) {
                ctx.fillText(authorP[j], 1764, Y, 827);
                Y = Y + authorK;
            }
            ctx.font = textSize + " Forum";
            for (let i = 0; i < textP.length; i++) {
                ctx.fillText(textP[i], 1764, Y, 827);
                Y = Y + textK;
            }

            var dataUrl = c.toDataURL();


            const link = document.createElement('a');
            link.download = 'chocolate_A4.png';
            link.href = get300dpi(dataUrl);
            link.click();
            link.delete;

            ctx.clearRect(0, 0, c.width, c.height);
            c.width = 0;
            c.height = 0;
        }
    };
}

async function makeStickers(layoutPath, textP, textK, textColor) {

    var textSize = textK + "px";

    var boxHeight = 400;
    var boxWidth = 670;
    var textX = 530;
    var textY = 340;
    var yInterval = 415;
    var xInterval = 155;

    var c = document.getElementById('stickers_canvas_id');
    document.body.appendChild(c);
    c.width = 3508;
    c.height = 2480;
    var ctx = c.getContext("2d");
    ctx.textAlign = 'center';

    var imageObj1 = new Image();
    imageObj1.src = layoutPath;
    imageObj1.onload = function () {
        ctx.drawImage(imageObj1, 0, 0, 3508, 2480);
        ctx.fillStyle = textColor;
        ctx.font = textSize + " Didona";
        var Y = textY;
        var X = textX;
        for (let a = 0; a < 3; a++) {
            for (let b = 0; b < 4; b++) {
                Y = textY + boxHeight * a + yInterval * a;
                X = textX + boxWidth * b + xInterval * b;
                for (let i = 0; i < textP[a + b * 3].length; i++) {
                    ctx.fillText(textP[a + b * 3][i], X, Y, boxWidth - 30);
                    Y = Y + textK * 1.2;
                };
            };     
        };
        const link = document.createElement('a');
        link.download = 'stickers_A4.png';
        link.href = c.toDataURL();
        link.click();
        link.delete;

        ctx.clearRect(0, 0, c.width, c.height);
        c.width = 0;
        c.height = 0;
    };
}

async function makeSweets(layoutPath, nameP, authorP, textP, textK, textColor) {
    var boxHeight = 930;
    var boxWidth = 1122;
    var x = 680;
    var textY = 640;
    var yInterval = 70;
    var xInterval = 60;

    var textSize = textK + "px";

    var c = document.getElementById('sweets_canvas_id');
    document.body.appendChild(c);
    c.width = 2480;
    c.height = 3508;
    var ctx = c.getContext("2d");
    ctx.textAlign = 'center';

    var imageObj1 = new Image();
    imageObj1.src = layoutPath;
    imageObj1.onload = function () {
        ctx.drawImage(imageObj1, 0, 0, 2480, 3508);
        ctx.fillStyle = textColor;
        var Y = textY;
        for (let a = 0; a < 3; a++) {
            ctx.font = textSize + " Didona";
            Y = textY + boxHeight * a + yInterval * a;
            for (let i = 0; i < textP[a].length; i++) {
                ctx.fillText(textP[a][i], x, Y, boxWidth);
                Y = Y + textK;
            };
            ctx.font = textSize + " Forum";
            Y = Y + textK;
            for (let j = 0; j < nameP[a].length; j++) {
                ctx.fillText(nameP[a][j], x, Y, boxWidth);
                Y = Y + textK;
            };
            ctx.fillText(authorP[a], x, Y, boxWidth);
        };

        x = x + boxWidth;
        for (let b = 3; b < 6; b++) {
            ctx.font = textSize + " Didona";
            Y = textY + boxHeight * (b - 3) + yInterval * (b - 3);
            for (let k = 0; k < textP[b].length; k++) {
                ctx.fillText(textP[b][k], x, Y, boxWidth);
                Y = Y + textK;
            };
            ctx.font = textSize + " Forum";
            Y = Y + textK;
            for (let l = 0; l < nameP[b].length; l++) {
                ctx.fillText(nameP[b][l], x, Y, boxWidth);
                Y = Y + textK;
            };
            ctx.fillText(authorP[b], x, Y, boxWidth);
        };

        const link = document.createElement('a');
        link.download = 'sweets_A4.png';
        link.href = c.toDataURL();
        link.click();
        link.delete;

        ctx.clearRect(0, 0, c.width, c.height);
        c.width = 0;
        c.height = 0;
    };
}

async function makeCover(layoutPath) {
    var c = document.getElementById('sweets_canvas_id');
    document.body.appendChild(c);
    c.width = 2480;
    c.height = 3508;
    var ctx = c.getContext("2d");
    ctx.textAlign = 'center';

    var imageObj1 = new Image();
    imageObj1.src = layoutPath;
    imageObj1.onload = function () {
        ctx.drawImage(imageObj1, 0, 0, 2480, 3508);

        const link = document.createElement('a');
        link.download = 'cover_A4.png';
        link.href = c.toDataURL();
        link.click();
        link.delete;

        ctx.clearRect(0, 0, c.width, c.height);
        c.width = 0;
        c.height = 0;
    };
}

async function makeBox(layoutPath, nameP, textP, textK, textColor) {
    var textSize = textK + "px";

    var boxWidth = 680;
    var xInterval = 170;
    var textX = 425;
    var textY = 1250;

    var boxHeight = 380;
    var yInterval = 200;

    var c = document.getElementById('box_canvas_id');
    document.body.appendChild(c);
    c.width = 3508;
    c.height = 4961;
    var ctx = c.getContext("2d");
    ctx.textAlign = 'center';

    var imageObj1 = new Image();
    imageObj1.src = layoutPath;
    imageObj1.onload = function () {
        ctx.drawImage(imageObj1, 0, 0, 3508, 4961);
        ctx.fillStyle = textColor;

        var Y = textY;
        var X = textX;

        for (let a = 0; a < 4; a++) {
            var lines = 3 + textP[a * 3].length + textP[a * 3 + 1].length + textP[a * 3 + 2].length;
            var inter = (1500 - lines * textK) / 2;
            Y = textY;
            for (let b = 0; b < 3; b++) {
                var boxLines = textP[a * 3 + b].length + 1;
                boxHeight = boxLines * textK;
                yInterval = inter;

                ctx.font = textSize + " Didona";
                X = textX + boxWidth * a + xInterval * a;
                ctx.fillText(nameP[a * 3 + b], X, Y, boxWidth - 30);
                Y = Y + textK;

                ctx.font = textSize + " Forum";
                for (let i = 0; i < textP[a * 3 + b].length; i++) {
                    ctx.fillText(textP[a * 3 + b][i], X, Y, boxWidth - 30);
                    Y = Y + textK;
                };
                Y = Y + yInterval;
            };
        };

        const link = document.createElement('a');
        link.download = 'box_A3.png';
        link.href = c.toDataURL();
        link.click();
        link.delete;

        ctx.clearRect(0, 0, c.width, c.height);
        c.width = 0;
        c.height = 0;
    };
}