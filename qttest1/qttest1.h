#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_qttest1.h"

class qttest1 : public QMainWindow
{
	Q_OBJECT

public:
	qttest1(QWidget *parent = Q_NULLPTR);

private:
	Ui::qttest1Class ui;
};
