import { createContext, useContext, useState } from 'react'

type CommandDialogContextType = {
  open: boolean
  setOpen: (open: boolean) => void
}

const CommandDialogContext = createContext<CommandDialogContextType | null>(
  null,
)

export function CommandDialogProvider({ children }) {
  const [open, setOpen] = useState(false)

  return (
    <CommandDialogContext.Provider value={{ open, setOpen }}>
      {children}
    </CommandDialogContext.Provider>
  )
}

export function useUniversalSearch() {
  const ctx = useContext(CommandDialogContext)
  if (!ctx) throw new Error('useCommandDialog must be used within provider')
  return ctx
}
