// Weapon

function startGame() {
    document.getElementById('gameTitle').style.display = 'none';
    document.getElementById('container').style.display = 'block';
    document.getElementById('infoRow').style.display = 'block';

    window.onkeydown = function catchDownKey(e) {

        switch (e.keyCode) {
            case 32:
                gun.showFire();
                pellets.add(gun);
                break;
            case 37:
                gun.setDirection('left');
                if (!gun.leftInterval) setLeftIntervalRotate(gun);
                break;
            case 39:
                gun.setDirection('right');
                if (!gun.rightInterval) setRightIntervalRotate(gun);
                break;
        }

    };

    window.onkeyup = function catchUpKey(e) {

        switch (e.keyCode) {
            case 32:
                gun.hideFire();
                break;
            case 37:
                clearInterval(gun.leftInterval);
                gun.leftInterval = 0;
                break;
            case 39:
                clearInterval(gun.rightInterval);
                gun.rightInterval = 0;
                break;
        }
    };

     gun = new Gun('weapon');

    setLeftIntervalMovePellets(pellets);
    upPelletCount(pellets);
    setIntervalParatrooper(trooper);
    planeFly();
    getParatrooper();
    plane.gameLoop = true;
    trooper.gameLoop = true;
}

document.getElementById('start').addEventListener('click', startGame, false);

function stopGame() {
    clearInterval(pellets.setIntervalMove);
    clearInterval(trooper.setIntervalMove);
    plane.gameLoop = false;
    plane.planeSoundStop();
    trooper.gameLoop = false;
    window.onkeyup = null;
    window.onkeydown = null;
}
