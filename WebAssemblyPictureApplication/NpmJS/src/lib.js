import { changeDpiDataUrl } from 'changedpi';

export function get300dpi(dataUrl) {
    return changeDpiDataUrl(dataUrl, 300);
}