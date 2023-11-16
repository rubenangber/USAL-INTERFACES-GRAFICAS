using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACTOMETRO {
    internal class Elecciones {
        public String nombre;
        public int escañosPP;
        public int escañosPSOE;
        public int escañosVOX;
        public int escañosSUMAR;
        public int escañosERC;
        public int escañosJUNTS;
        public int escañosBILDU;
        public int escañosPNV;
        public int escañosBNG;
        public int escañosCCA;
        public int escañosUPN;

        public Elecciones() {

        }

        public Elecciones(String nombre, int escañosPP, int escañosPSOE, int escañosVOX, int escañosSUMAR, int escañosERC, int escañosJUNTS, int escañosBILDU, int escañosPNV, int escañosBNG, int escañosCCA, int escañosUPN) {
            this.nombre = nombre;
            this.escañosPP = escañosPP;
            this.escañosPSOE = escañosPSOE;
            this.escañosVOX = escañosVOX;
            this.escañosSUMAR = escañosSUMAR;
            this.escañosERC = escañosERC;
            this.escañosJUNTS = escañosJUNTS;
            this.escañosBILDU = escañosBILDU;
            this.escañosPNV = escañosPNV;
            this.escañosBNG = escañosBNG;
            this.escañosCCA = escañosCCA;
            this.escañosUPN = escañosUPN;
        }

        public String getNombre() {
            return nombre;
        }

        public void setNombre(String nombre) {
            this.nombre = nombre;
        }

        public int getEscañosPP() {
            return escañosPP;
        }

        public void setEscañosPP(int escañosPP) {
            this.escañosPP = escañosPP;
        }

        public int getEscañosPSOE() {
            return escañosPSOE;
        }

        public void setEscañosPSOE(int escañosPSOE) {
            this.escañosPSOE = escañosPSOE;
        }

        public int getEscañosVOX() {
            return escañosVOX;
        }

        public void setEscañosVOX(int escañosVOX) {
            this.escañosVOX = escañosVOX;
        }

        public int getEscañosSUMAR() {
            return escañosSUMAR;
        }

        public void setEscañosSUMAR(int escañosSUMAR) {
            this.escañosSUMAR = escañosSUMAR;
        }

        public int getEscañosERC() {
            return escañosERC;
        }

        public void setEscañosERC(int escañosERC) {
            this.escañosERC = escañosERC;
        }

        public int getEscañosJUNTS() {
            return escañosJUNTS;
        }

        public void setEscañosJUNTS(int escañosJUNTS) {
            this.escañosJUNTS = escañosJUNTS;
        }

        public int getEscañosBILDU() {
            return escañosBILDU;
        }

        public void setEscañosBILDU(int escañosBILDU) {
            this.escañosBILDU = escañosBILDU;
        }

        public int getEscañosPNV() {
            return escañosPNV;
        }

        public void setEscañosPNV(int escañosPNV) {
            this.escañosPNV = escañosPNV;
        }

        public int getEscañosBNG() {
            return escañosBNG;
        }

        public void setEscañosBNG(int escañosBNG) {
            this.escañosBNG = escañosBNG;
        }

        public int getEscañosCCA() {
            return escañosCCA;
        }

        public void setEscañosCCA(int escañosCCA) {
            this.escañosCCA = escañosCCA;
        }

        public int getEscañosUPN() {
            return escañosUPN;
        }

        public void setEscañosUPN(int escañosUPN) {
            this.escañosUPN = escañosUPN;
        }
    }
}
